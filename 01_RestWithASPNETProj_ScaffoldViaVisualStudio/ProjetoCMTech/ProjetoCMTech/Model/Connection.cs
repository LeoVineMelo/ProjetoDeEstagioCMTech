using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
   
    public class Connection
    {

        public long Id { get; set; }

       
        [ForeignKey("Usuario")]
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public bool IsOnline { get; set; }

        public string SignalrId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
