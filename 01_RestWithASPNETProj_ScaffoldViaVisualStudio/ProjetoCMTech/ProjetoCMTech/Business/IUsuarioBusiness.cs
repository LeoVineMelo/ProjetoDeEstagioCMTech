using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IUsuarioBusiness
    {
        UsuarioVO Create(UsuarioVO usuario);

        UsuarioVO FindByID(long id);
        List<UsuarioVO> FindAll();

        UsuarioVO Update(UsuarioVO usuario);

        void Delete(long id);

    }
}
