using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class UsuarioConverter : IParser<UsuarioVO, Usuario>, IParser<Usuario, UsuarioVO>
    {
        private readonly PerfilConverter _perfilCoverter;
        private readonly DepartamentoConverter _departamentoCoverter;
        private readonly OrganizacaoConverter _organizacaoCoverter;
        public UsuarioConverter()
        { 
            _departamentoCoverter = new DepartamentoConverter();
            _organizacaoCoverter = new OrganizacaoConverter();
            _perfilCoverter = new PerfilConverter();
        }

        public Usuario Parse(UsuarioVO origin)
        {
            if (origin == null) return null;
            return new Usuario
            {
                Id = origin.Id,
                DepartamentoId = origin.DepartamentoId,
                Departamento = _departamentoCoverter.Parse(origin.Departamento),
                OrganizacaoId = origin.OrganizacaoId,
                Organizacao = _organizacaoCoverter.Parse(origin.Organizacao),
                PerfilId = origin.PerfilId,
                Perfil = _perfilCoverter.Parse(origin.Perfil),
                Nome = origin.Nome,
                Email = origin.Email,
                Senha = origin.Senha,
                DataCadastro = origin.DataCadastro,
                

            };
        }
        public UsuarioVO Parse(Usuario origin)
        {
            if (origin == null) return null;
            return new UsuarioVO
            {
                Id = origin.Id,
                DepartamentoId = origin.DepartamentoId,
                Departamento = _departamentoCoverter.Parse(origin.Departamento),
                OrganizacaoId = origin.OrganizacaoId,
                Organizacao = _organizacaoCoverter.Parse(origin.Organizacao),
                PerfilId = origin.PerfilId,
                Perfil =  _perfilCoverter.Parse(origin.Perfil), 
                Nome = origin.Nome,
                Email = origin.Email,
                Senha = origin.Senha,
                DataCadastro = origin.DataCadastro,
            };
        }

        public List<UsuarioVO> Parse(List<Usuario> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<Usuario> Parse(List<UsuarioVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
