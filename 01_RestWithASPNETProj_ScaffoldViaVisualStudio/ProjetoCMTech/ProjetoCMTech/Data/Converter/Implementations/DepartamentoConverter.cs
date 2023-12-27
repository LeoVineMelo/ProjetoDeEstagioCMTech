using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class DepartamentoConverter : IParser<DepartamentoVO, Departamento>, IParser<Departamento, DepartamentoVO>
    {
        private readonly OrganizacaoConverter _organizacaoConverter;
        public DepartamentoConverter()
        {
            _organizacaoConverter = new OrganizacaoConverter();

        }
        public Departamento Parse(DepartamentoVO origin)
        {
            if (origin == null) return null;
            return new Departamento
            {
                Id = origin.Id,
                OrganizacaoId = origin.OrganizacaoId,
                Organizacao = _organizacaoConverter.Parse(origin.Organizacao),
                Nome = origin.Nome, 

            };
        }
        public DepartamentoVO Parse(Departamento origin)
        {
            if (origin == null) return null;
            return new DepartamentoVO
            {
                Id = origin.Id,
                OrganizacaoId = origin.OrganizacaoId,
                Organizacao = _organizacaoConverter.Parse(origin.Organizacao),
                Nome = origin.Nome,
            };
        }

        public List<DepartamentoVO> Parse(List<Departamento> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<Departamento> Parse(List<DepartamentoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
