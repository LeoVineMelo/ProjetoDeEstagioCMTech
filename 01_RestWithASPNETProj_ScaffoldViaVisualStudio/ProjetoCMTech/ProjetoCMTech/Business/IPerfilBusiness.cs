using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IPerfilBusiness
    {
        PerfilVO Create(PerfilVO perfil);

        PerfilVO FindByID(long id);
        List<PerfilVO> FindAll();

        PerfilVO Update(PerfilVO perfil);

        void Delete(long id);

    }
}
