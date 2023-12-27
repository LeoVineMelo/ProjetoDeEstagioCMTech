using ProjetoCMTech.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Data.VO
{
    public class ChatMessageVO
    {
        public int Id { get; set; }


        public Usuario SenderUsuario { get; set; }
        public long SenderUsuarioId { get; set; }

        public Usuario ReceiverUsuario { get; set; }
        public int ReceiverUsuarioId { get; set; }

        public string Usuario { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
