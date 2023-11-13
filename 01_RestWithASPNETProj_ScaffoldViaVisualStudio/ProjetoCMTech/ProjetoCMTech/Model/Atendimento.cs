using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    [Table("atendimento")]
    public class Atendimento
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("status_atendimento_id")]
        public long StatusAtendimentoId { get; set; }
        [Column("departamento_id")]
        public int DepartamentoId { get; set; }
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        [Column("cliente_id")]
        public int ClienteId { get; set; }
        [Column("organizacao_id")]
        public int OrganizacaoId { get; set; }
        [Column("data_hora_atendimento")]
        public DateTime DataHoraAtendimento { get; set; }
       
    }
}
