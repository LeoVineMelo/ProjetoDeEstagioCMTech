using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class PerfilCoverter : IParser<PerfilVO, Perfil>, IParser<Perfil, PerfilVO>
    {
        public Perfil Parse(PerfilVO origin)
        {
            if (origin == null) return null;
            return new Perfil
            {
                Id = origin.Id,
                Nome = origin.Nome,

            };
        }
        public PerfilVO Parse(Perfil origin)
        {
            if (origin == null) return null;
            return new PerfilVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
            };
        }

        public List<PerfilVO> Parse(List<Perfil> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<Perfil> Parse(List<PerfilVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
