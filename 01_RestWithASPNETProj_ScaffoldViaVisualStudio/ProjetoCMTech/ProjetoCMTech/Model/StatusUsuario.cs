using Microsoft.IdentityModel.Protocols.WSTrust;
using ProjetoCMTech.Data.VO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    public class StatusUsuario
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("usuario")]
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }


        [NotMapped]
        public Status Status { get; set; }

        public int GetStatus(Status status)
        {
            return status.valor;
        }
    } 
} 