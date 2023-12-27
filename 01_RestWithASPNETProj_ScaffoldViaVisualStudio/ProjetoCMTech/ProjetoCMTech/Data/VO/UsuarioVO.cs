using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoCMTech.Model
{

    public class UsuarioVO
    {
        public UsuarioVO(long id, string? nome, string signalrId)
        {
            Id = id;
            Nome = nome;
            SignalrId = signalrId;
        }

        public UsuarioVO()
        {
        }

        public long Id { get; set; }

        public long? DepartamentoId { get; set; }
        public DepartamentoVO? Departamento { get; set; }

        public long? OrganizacaoId { get; set; }
        public OrganizacaoVO? Organizacao { get; set; }

        public long PerfilId { get; set; }
        public PerfilVO Perfil { get; set; }

        public string? Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
        public string SignalrId { get; set; }

       
    }
}
