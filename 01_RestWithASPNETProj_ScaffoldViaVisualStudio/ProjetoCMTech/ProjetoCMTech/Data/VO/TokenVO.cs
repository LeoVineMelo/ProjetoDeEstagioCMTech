using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.VO
{
    public class TokenVO
    {
        public TokenVO(bool authenticated, string created, string expiration, string accessToken, UsuarioVO usuario)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            Usuario = usuario;
        }

        public Boolean Authenticated { get; set; }

        public String Created { get; set; }

        public String Expiration { get; set; }

        public String AccessToken { get; set; }

        public UsuarioVO Usuario { get; set; }


    }
}
