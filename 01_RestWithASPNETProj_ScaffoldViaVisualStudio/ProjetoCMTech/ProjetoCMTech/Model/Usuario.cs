using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{

    public class Usuario
    {

        public long Id { get; set; }
        [ForeignKey("Departamento")]

        public long? DepartamentoId { get; set; }

        public Departamento? Departamento { get; set; }
        [ForeignKey("Organizacao")]

        public long? OrganizacaoId { get; set; }

        public Organizacao? Organizacao { get; set; }
        
        [ForeignKey("Perfil")]

        public long PerfilId { get; set; }

        public Perfil Perfil { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public IEnumerable<Atendimento> Atendimentos { get; set; }

        public IEnumerable<Atendimento> AtendimentosClientes { get; set; }

        public IEnumerable<ChatAtendimento> ChatAtendimentoRemetentes { get; set; }

        public IEnumerable<ChatAtendimento> ChatAtendimentoDestinatarios { get; set; }

        public IEnumerable<Connection> Connections { get; set; }


    }
}
