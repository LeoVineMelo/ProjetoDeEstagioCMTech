using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    public class AtendimentoVO
    {
        public long Id { get; set; }

        public long StatusAtendimentoId { get; set; }

        public int DepartamentoId { get; set; }

        public int UsuarioId { get; set; }

        public int ClienteId { get; set; }

        public int OrganizacaoId { get; set; }

        public DateTime DataHoraAtendimento { get; set; }
       
    }
}
