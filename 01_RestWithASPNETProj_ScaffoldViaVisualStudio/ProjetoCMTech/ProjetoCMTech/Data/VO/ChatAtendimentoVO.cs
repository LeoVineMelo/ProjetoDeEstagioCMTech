using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{

    public class ChatAtendimentoVO
    {

        public long Id { get; set; }

        public long AtendimentoId { get; set; }
        public AtendimentoVO Atendimento { get; set; }

        public long RemetenteId { get; set; }
        public UsuarioVO Remetente { get; set; }

        public long DestinatarioId { get; set; }
        public UsuarioVO Destinatario { get; set; }

        public DateTime DataHora { get; set; }

        public string Mensagem { get; set; }

    }
}
