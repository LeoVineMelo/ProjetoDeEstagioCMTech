using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class AtendimentoCoverter : IParser<AtendimentoVO, Atendimento>, IParser<Atendimento, AtendimentoVO>
    {
        public Atendimento Parse(AtendimentoVO origin)
        {
            if (origin == null) return null;
            return new Atendimento
            {
                Id = origin.Id,
                StatusAtendimentoId = origin.StatusAtendimentoId,
                DepartamentoId = origin.DepartamentoId,
                UsuarioId = origin.UsuarioId,
                ClienteId = origin.ClienteId,
                OrganizacaoId = origin.OrganizacaoId,
                DataHoraAtendimento = origin.DataHoraAtendimento,
            };
        }
        public AtendimentoVO Parse(Atendimento origin)
        {
            if (origin == null) return null;
            return new AtendimentoVO
            {
                Id = origin.Id,
                StatusAtendimentoId = origin.StatusAtendimentoId,
                DepartamentoId = origin.DepartamentoId,
                UsuarioId = origin.UsuarioId,
                ClienteId = origin.ClienteId,
                OrganizacaoId = origin.OrganizacaoId,
                DataHoraAtendimento = origin.DataHoraAtendimento,
            };
        }

        public List<AtendimentoVO> Parse(List<Atendimento> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<Atendimento> Parse(List<AtendimentoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
