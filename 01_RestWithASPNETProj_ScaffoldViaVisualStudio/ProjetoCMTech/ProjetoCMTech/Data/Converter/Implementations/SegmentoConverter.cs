using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class SegmentoConverter : IParser<SegmentoVO, Segmento>, IParser<Segmento, SegmentoVO>
    {
        public Segmento Parse(SegmentoVO origin)
        {
            if (origin == null) return null;
            return new Segmento
            {
                Id = origin.Id,
                Nome = origin.Nome,

            };
        }
        public SegmentoVO Parse(Segmento origin)
        {
            if (origin == null) return null;
            return new SegmentoVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
            };
        }

        public List<SegmentoVO> Parse(List<Segmento> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<Segmento> Parse(List<SegmentoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
