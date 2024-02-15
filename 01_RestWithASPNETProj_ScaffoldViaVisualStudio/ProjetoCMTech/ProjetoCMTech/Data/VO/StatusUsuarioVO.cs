using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.VO
{
    public class StatusUsuarioVO
    {
        public long id;
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Status Status { get; set; }
    }
}
