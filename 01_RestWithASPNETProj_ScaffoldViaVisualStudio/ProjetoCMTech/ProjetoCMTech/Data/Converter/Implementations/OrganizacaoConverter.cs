using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class OrganizacaoConverter : IParser<OrganizacaoVO, Organizacao>, IParser<Organizacao, OrganizacaoVO>
    {
        private readonly SegmentoConverter _segmentoConverter;
        private readonly GrupoConverter _grupoConverter;

        public OrganizacaoConverter()
        {
            _segmentoConverter = new SegmentoConverter();
            _grupoConverter = new GrupoConverter();

        }
        public Organizacao Parse(OrganizacaoVO origin)
        {
            if (origin == null) return null;
            return new Organizacao
            {
                Id = origin.Id,
                SegmentoId = origin.SegmentoId,
                Segmento = _segmentoConverter.Parse(origin.Segmento),
                GrupoId = origin.GrupoId,
                Grupo = _grupoConverter.Parse(origin.Grupo),
                Nome = origin.Nome,
                Telefone = origin.Telefone,
            };
        }
        public OrganizacaoVO Parse(Organizacao origin)
        {
            if (origin == null) return null;
            return new OrganizacaoVO
            {
                Id = origin.Id,
                SegmentoId = origin.SegmentoId,
                Segmento = _segmentoConverter.Parse(origin.Segmento),
                GrupoId = origin.GrupoId,
                Grupo = _grupoConverter.Parse(origin.Grupo),
                Nome = origin.Nome,
                Telefone = origin.Telefone,
            };
        }

        public List<OrganizacaoVO> Parse(List<Organizacao> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<Organizacao> Parse(List<OrganizacaoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
