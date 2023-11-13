using Microsoft.IdentityModel.Tokens;
using ProjetoCMTech.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;



namespace ProjetoCMTech.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private TokenConf _conf;

        public TokenService(TokenConf conf)
        {
            _conf = conf;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var options = new JwtSecurityToken(
                issuer: _conf.Issuer,
                audience: _conf.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_conf.Minutes),
                signingCredentials: signinCredentials
                );


            string TokenString = new JwtSecurityTokenHandler().WriteToken(options);
            return TokenString;
        }



        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParametes = new TokenValidationParameters { 
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf.Secret)),
                ValidateLifetime = false,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var pricipal = tokenHandler.ValidateToken(token, tokenValidationParametes, out securityToken);
            var jwtSecuritToken = securityToken as JwtSecurityToken;
            if (jwtSecuritToken == null ||
                !jwtSecuritToken.Header.Alg.Equals(
                    SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCulture))
                throw new SecurityTokenException("Token Inválido");
            return pricipal;
        }
    }
}
