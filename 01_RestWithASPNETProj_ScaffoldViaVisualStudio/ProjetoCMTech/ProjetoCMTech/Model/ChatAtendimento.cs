using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    
    public class ChatAtendimento
    {


        public long Id { get; set; }
        [ForeignKey("Atendimento")]

        public long AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; }
        [ForeignKey("Remetente")]

        public long RemetenteId { get; set; }
        public Usuario Remetente { get; set; }
        [ForeignKey("Destinatario")]

        public long DestinatarioId { get; set; }
        public Usuario Destinatario { get; set; }

        public DateTime DataHora { get; set; }

        public string Mensagem { get; set; }

    }
}
