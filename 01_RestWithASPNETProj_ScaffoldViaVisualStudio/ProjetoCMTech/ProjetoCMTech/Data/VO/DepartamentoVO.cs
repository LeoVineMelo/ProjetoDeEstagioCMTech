using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{

    public class DepartamentoVO
    {

        public long Id { get; set; }

        public long OrganizacaoId { get; set; }
        public OrganizacaoVO Organizacao { get; set; }

        public string Nome { get; set; }

    }
}
