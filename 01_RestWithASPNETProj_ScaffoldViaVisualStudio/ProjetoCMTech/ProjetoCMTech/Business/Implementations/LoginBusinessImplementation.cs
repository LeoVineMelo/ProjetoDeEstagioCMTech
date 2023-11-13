using ProjetoCMTech.Configuration;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using ProjetoCMTech.Repository;
using ProjetoCMTech.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjetoCMTech.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConf _conf;

        private IUsuarioRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConf conf, IUsuarioRepository repository, ITokenService tokenService)
        {
            _conf = conf;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UsuarioVO usuarioCredentials)
        {
            var usuario = _repository.ValidateCredentials(usuarioCredentials);
            if (usuario == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email)

            };
            var accessToken = _tokenService.GenerateAccessToken(claims);


            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_conf.Minutes);


            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT)
                , expirationDate.ToString(DATE_FORMAT),
                accessToken
               
                );
        }
    }
}
