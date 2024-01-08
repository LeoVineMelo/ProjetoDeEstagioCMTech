using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Hubs;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;

namespace ProjetoCMTech.Hubs
{
    public class ChatHub : Hub
    {   
        private readonly PostgreSQLContext _context;
        private readonly ChatAtendimentoConverter _coverter;

        public ChatHub(PostgreSQLContext context)
        {
            _context = context;
            _coverter = new ChatAtendimentoConverter();
        }

        public async Task getOnlineUsuarios()
        {
            long UsuarioId = _context.Connection.Where(c => c.SignalrId == Context.ConnectionId).Select(c => c.UsuarioId).SingleOrDefault();
            List<UsuarioVO> onlineUsuarios = _context.Connection
                .Where(c => c.UsuarioId != UsuarioId)
                .Select(c =>
                    new UsuarioVO(c.UsuarioId, _context.Usuarios.Where(p => p.Id == c.UsuarioId).Select(p => p.Nome).SingleOrDefault(), c.SignalrId)
                ).ToList();
            await Clients.Caller.SendAsync("getOnlineUsuarioResponse", onlineUsuarios);
        }

        public async Task getUsuarioMessages(string connId)
        {
            long currentUsuarioId = _context.Connection.Where(c => c.SignalrId == Context.ConnectionId).Select(c => c.UsuarioId).SingleOrDefault();
            long receiverUsuarioId = _context.Connection.Where(c => c.SignalrId == connId).Select(c => c.UsuarioId).SingleOrDefault();
            List<ChatAtendimento> ChatAtendimentos = _context.ChatAtendimentos.Where(c => (c.RemetenteId == currentUsuarioId && c.DestinatarioId == receiverUsuarioId) || (c.DestinatarioId == currentUsuarioId && c.RemetenteId == receiverUsuarioId)).OrderBy(c => c.DataHora).ToList();

            await Clients.Caller.SendAsync("getUsuarioMessagesResponse", ChatAtendimentos);
        }

        public async Task sendMsg(string connId, string msg)
        {
            long UsuarioId = _context.Connection.Where(c => c.SignalrId == Context.ConnectionId).Select(c => c.UsuarioId).SingleOrDefault();
            string usuarioName = _context.Usuarios.Where(p => p.Id == UsuarioId).Select(p => p.Nome).SingleOrDefault();

            long receiverUsuarioId = _context.Connection.Where(c => c.SignalrId == connId).Select(c => c.UsuarioId).SingleOrDefault();

            var ChatAtendimentos = new ChatAtendimento
            {
                RemetenteId = UsuarioId,
                DestinatarioId = receiverUsuarioId,
                Mensagem = msg,
                DataHora = DateTime.Now,
            };

            await _context.ChatAtendimentos.AddAsync(ChatAtendimentos);
            await _context.SaveChangesAsync();

            ChatAtendimentoVO vo = _coverter.Parse(ChatAtendimentos);

            await Clients.Client(connId).SendAsync("sendMsgResponse", Context.ConnectionId, usuarioName, msg);
            await Clients.Caller.SendAsync("sendMsgResponse", Context.ConnectionId, usuarioName, msg);
        }

        public async Task authMe(int usuarioId)
        {
            string SignalrID = Context.ConnectionId;
            Usuario tempUsuario = await _context.Usuarios.Where(p => p.Id == usuarioId).SingleOrDefaultAsync();
            if (tempUsuario != null) //if credentials are correct
            {
                Console.WriteLine("\n" + tempUsuario.Nome + " logged in" + "\nSignalrID: " + SignalrID);

                var conn = await _context.Connection.Where(c => c.UsuarioId == tempUsuario.Id).FirstOrDefaultAsync();
                if (conn == null)
                {
                    Connection currUsuario = new Connection
                    {
                        UsuarioId = (int)tempUsuario.Id,
                        IsOnline = true,
                        SignalrId = SignalrID,
                        TimeStamp = DateTime.Now
                    };
                    await _context.Connection.AddAsync(currUsuario);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    conn.SignalrId = SignalrID;
                    conn.IsOnline = true;
                    conn.TimeStamp = DateTime.Now;

                    _context.Connection.Update(conn);
                    await _context.SaveChangesAsync();
                }

                UsuarioVO newUsuario = new UsuarioVO(tempUsuario.Id, tempUsuario.Nome, SignalrID);
                await Clients.Caller.SendAsync("authMeResponseSuccess", newUsuario);//4Tutorial
                await Clients.Others.SendAsync("usuarioOn", newUsuario);//4Tutorial
            }

            else //if credentials are incorrect
            {
                await Clients.Caller.SendAsync("authMeResponseFail");
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var conn = _context.Connection.Where(c => c.SignalrId == Context.ConnectionId).SingleOrDefault();
            if (conn != null)
            {
                conn.IsOnline = false;

                _context.Connection.Update(conn);
                _context.SaveChangesAsync();

                Clients.Others.SendAsync("usuarioOff", conn.UsuarioId);
            }
            return base.OnDisconnectedAsync(exception);
        }

        public void logOut(int usuarioId)
        {
            var conn = _context.Connection.Where(c => c.UsuarioId == usuarioId).SingleOrDefault();
            if (conn != null)
            {
                conn.IsOnline = false;

                _context.Connection.Update(conn);
                _context.SaveChangesAsync();

                Clients.Caller.SendAsync("logoutResponse");
                Clients.Others.SendAsync("usuarioOff", usuarioId);
            }
        }
    }
}