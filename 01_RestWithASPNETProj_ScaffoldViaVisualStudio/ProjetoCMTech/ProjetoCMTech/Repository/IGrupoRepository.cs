using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IGrupoRepository
    {
        Grupo Create(Grupo grupo);

        Grupo FindByID(long id);
        List<Grupo> FindAll();

        Grupo Update(Grupo grupo);

        void Delete(long id);

        bool Exists(long id);

    }
}
