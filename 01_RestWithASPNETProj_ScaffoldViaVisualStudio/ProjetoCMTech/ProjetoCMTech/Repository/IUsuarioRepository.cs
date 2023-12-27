using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IUsuarioRepository
    {
        Usuario ValidateCredentials(UsuarioLoginVO usuario);
        Usuario Create(Usuario usuario);

        Usuario FindByID(long id);
        List<Usuario> FindAll(UserPesquisaVO pesquisa = null);
        int FindAllCount(UserPesquisaVO pesquisa = null);
        Usuario Update(Usuario usuario);

        void Delete(long id);

        bool Exists(long id);

    }
}
