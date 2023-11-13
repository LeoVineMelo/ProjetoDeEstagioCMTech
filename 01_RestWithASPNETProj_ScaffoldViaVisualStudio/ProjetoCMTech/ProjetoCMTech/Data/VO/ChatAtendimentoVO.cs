using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{

    public class ChatAtendimentoVO
    {

        public long Id { get; set; }

        public long AtendimentoId { get; set; }

        public string Rementente { get; set; }

        public string Destinatario { get; set; }

        public string DataHora { get; set; }

        public string Mensagem { get; set; }

    }
}
