using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class StatusAtendimentoConverter : IParser<StatusAtendimentoVO, StatusAtendimento>, IParser<StatusAtendimento, StatusAtendimentoVO>
    {
        public StatusAtendimento Parse(StatusAtendimentoVO origin)
        {
            if (origin == null) return null;
            return new StatusAtendimento
            {
                Id = origin.Id,
                Nome = origin.Nome,

            };
        }
        public StatusAtendimentoVO Parse(StatusAtendimento origin)
        {
            if (origin == null) return null;
            return new StatusAtendimentoVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
            };
        }

        public List<StatusAtendimentoVO> Parse(List<StatusAtendimento> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<StatusAtendimento> Parse(List<StatusAtendimentoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
