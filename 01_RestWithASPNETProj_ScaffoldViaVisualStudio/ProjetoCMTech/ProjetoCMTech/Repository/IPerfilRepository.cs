using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IPerfilRepository
    {
        Perfil Create(Perfil perfil);

        Perfil FindByID(long id);
        List<Perfil> FindAll();

        Perfil Update(Perfil perfil);

        void Delete(long id);

        bool Exists(long id);

    }
}
