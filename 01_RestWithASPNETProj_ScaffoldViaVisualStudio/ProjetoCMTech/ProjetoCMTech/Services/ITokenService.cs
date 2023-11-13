using System.Security.Claims;

namespace ProjetoCMTech.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);

        

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
