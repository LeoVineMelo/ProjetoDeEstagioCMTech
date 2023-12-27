using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    public class AtendimentoVO
    {
        public long Id { get; set; }

        public long StatusAtendimentoId { get; set; }
        public StatusAtendimentoVO StatusAtendimento { get; set; }

        public long DepartamentoId { get; set; }
        public DepartamentoVO Departamento { get; set; }

        public long UsuarioId { get; set; }
        public UsuarioVO Usuario { get; set; }

        public long ClienteId { get; set; }
        public UsuarioVO Cliente { get; set; }

        public long OrganizacaoId { get; set; }
        public OrganizacaoVO Organizacao { get; set; }

        public DateTime DataHoraAtendimento { get; set; }
       
    }
}
