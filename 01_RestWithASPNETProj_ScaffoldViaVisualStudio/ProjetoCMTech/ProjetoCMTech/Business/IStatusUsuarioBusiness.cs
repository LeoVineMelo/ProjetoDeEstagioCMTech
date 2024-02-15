using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IStatusUsuarioBusiness
    {
        StatusUsuarioVO Create(StatusUsuarioVO statusUsuario);

        StatusUsuarioVO FindByID(long id);
        List<StatusUsuarioVO> FindAll();

        StatusUsuarioVO Update(StatusUsuarioVO statusUsuario);

        void Delete(long id);

    }
}
