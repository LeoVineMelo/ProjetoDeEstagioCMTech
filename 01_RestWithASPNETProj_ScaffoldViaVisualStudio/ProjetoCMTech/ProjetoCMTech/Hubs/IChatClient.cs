using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using System.Reflection.Emit;

namespace ProjetoCMTech.Hubs
{
    public interface IChatClient
    {
    
    Task ReceiveMessage(ChatAtendimentoVO message);

    Task SendAsync(string method, object?[] args, CancellationToken cancellationToken);
        Task SendAsync(string v, string connectionId, List<UsuarioVO> onlineUsuarios);
        Task SendAsync(string v, List<UsuarioVO> onlineUsuarios);
        Task SendAsync(string v, List<ChatAtendimento> chatMessages);
        Task SendAsync(string v, string connectionId, string usuarioName, string msg);
        Task SendAsync(string v, UsuarioVO newUsuario);
        Task SendAsync(string v, int usuarioId);
        Task SendAsync(string v);
    }

}
