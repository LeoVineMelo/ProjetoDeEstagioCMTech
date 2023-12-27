using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IUsuarioBusiness
    {
        UsuarioVO Create(UsuarioVO usuario);

        UsuarioVO FindByID(long id);
        List<UsuarioVO> FindAll(UserPesquisaVO pesquisa = null);
        int FindAllCount(UserPesquisaVO pesquisa = null);

        UsuarioVO Update(UsuarioVO usuario);

        void Delete(long id);

    }
}
