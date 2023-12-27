using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{

    public class Atendimento
    {


        public long Id { get; set; }
        [ForeignKey("StatusAtendimento")]
        [Column("status_atendimento_id")]
        public long StatusAtendimentoId { get; set; }
        public StatusAtendimento StatusAtendimento { get; set; }
        [ForeignKey("Departamento")]

        public long DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        [ForeignKey("Usuario")]

        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("Cliente")]

        public long ClienteId { get; set; }
        public Usuario Cliente { get; set; }
        [ForeignKey("Organizacao")]

        public long OrganizacaoId { get; set; }
        public Organizacao Organizacao { get; set; }

        public DateTime DataHoraAtendimento { get; set; }

        public IEnumerable<ChatAtendimento> ChatAtendimentos { get; set; }
       
    }
}
