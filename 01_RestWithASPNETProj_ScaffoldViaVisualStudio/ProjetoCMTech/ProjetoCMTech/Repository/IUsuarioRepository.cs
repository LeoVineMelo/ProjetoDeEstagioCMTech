using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IUsuarioRepository
    {
        Usuario ValidateCredentials(UsuarioVO usuario);
        Usuario Create(Usuario usuario);

        Usuario FindByID(long id);
        List<Usuario> FindAll();

        Usuario Update(Usuario usuario);

        void Delete(long id);

        bool Exists(long id);

    }
}
