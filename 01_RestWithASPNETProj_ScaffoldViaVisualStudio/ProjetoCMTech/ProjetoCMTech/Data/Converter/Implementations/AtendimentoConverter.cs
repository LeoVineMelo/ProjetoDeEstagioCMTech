using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class AtendimentoConverter : IParser<AtendimentoVO, Atendimento>, IParser<Atendimento, AtendimentoVO>
    {
        private readonly UsuarioConverter _usuarioCoverter;
        private readonly DepartamentoConverter _departamentoCoverter;
        private readonly OrganizacaoConverter _organizacaoCoverter;
        private readonly StatusAtendimentoConverter _statusAtendimentoConverter;

        public AtendimentoConverter()
        {
            _departamentoCoverter = new DepartamentoConverter();
            _organizacaoCoverter = new OrganizacaoConverter();
            _usuarioCoverter = new UsuarioConverter();
            _statusAtendimentoConverter = new StatusAtendimentoConverter();
        }

        public Atendimento Parse(AtendimentoVO origin)
        {
            if (origin == null) return null;
            return new Atendimento
            {
                Id = origin.Id,
                StatusAtendimentoId = origin.StatusAtendimentoId,
                StatusAtendimento = _statusAtendimentoConverter.Parse(origin.StatusAtendimento),
                DepartamentoId = origin.DepartamentoId,
                Departamento = _departamentoCoverter.Parse(origin.Departamento),
                UsuarioId = origin.UsuarioId,
                Usuario = _usuarioCoverter.Parse(origin.Usuario),
                ClienteId = origin.ClienteId,
                Cliente = _usuarioCoverter.Parse(origin.Cliente),
                OrganizacaoId = origin.OrganizacaoId,
                Organizacao = _organizacaoCoverter.Parse(origin.Organizacao),
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
                StatusAtendimento = _statusAtendimentoConverter.Parse(origin.StatusAtendimento),
                DepartamentoId = origin.DepartamentoId,
                Departamento = _departamentoCoverter.Parse(origin.Departamento),
                UsuarioId = origin.UsuarioId,
                Usuario = _usuarioCoverter.Parse(origin.Usuario),
                ClienteId = origin.ClienteId,
                Cliente = _usuarioCoverter.Parse(origin.Cliente),
                OrganizacaoId = origin.OrganizacaoId,
                Organizacao = _organizacaoCoverter.Parse(origin.Organizacao),
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
