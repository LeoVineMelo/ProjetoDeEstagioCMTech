using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UsuarioLoginVO usuario);
    }
}
