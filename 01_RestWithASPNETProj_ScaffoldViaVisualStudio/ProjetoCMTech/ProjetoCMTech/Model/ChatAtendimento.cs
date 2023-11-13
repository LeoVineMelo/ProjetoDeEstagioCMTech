using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    [Table("chat_atendimento")]
    public class ChatAtendimento
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("atendimento_id")]
        public long AtendimentoId { get; set; }
        [Column("rementente")]
        public string Rementente { get; set; }
        [Column("destinatario")]
        public string Destinatario { get; set; }
        [Column("data_hora")]
        public string DataHora { get; set; }
        [Column("mensagem")]
        public string Mensagem { get; set; }

    }
}
