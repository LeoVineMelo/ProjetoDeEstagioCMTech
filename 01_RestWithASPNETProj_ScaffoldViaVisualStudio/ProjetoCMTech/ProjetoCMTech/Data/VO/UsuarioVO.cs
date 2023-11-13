using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{

    public class UsuarioVO
    {

        public long Id { get; set; }

        public int? DepartamentoId { get; set; }

        public int? OrganizacaoId { get; set; }

        public int PerfilId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
