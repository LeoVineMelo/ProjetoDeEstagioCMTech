using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    
    public class Departamento
    {

        public long Id { get; set; }
        [ForeignKey("Organizacao")]

        public long OrganizacaoId { get; set; }
        public Organizacao Organizacao { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Atendimento> Atendimentos { get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }

    }
}
