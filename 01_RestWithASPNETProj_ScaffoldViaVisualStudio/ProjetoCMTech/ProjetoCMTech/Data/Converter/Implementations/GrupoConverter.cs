using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class GrupoConverter : IParser<GrupoVO, Grupo>, IParser<Grupo, GrupoVO>
    {
        public Grupo Parse(GrupoVO origin)
        {
            if (origin == null) return null;
            return new Grupo
            {
                Id = origin.Id,
                Nome = origin.Nome,
 
            };
        }
        public GrupoVO Parse(Grupo origin)
        {
            if (origin == null) return null;
            return new GrupoVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
            };
        }

        public List<GrupoVO> Parse(List<Grupo> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<Grupo> Parse(List<GrupoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
