using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IChangelogRepository
    {
        Changelog Create(Changelog changelog);

        Changelog FindByID(long id);
        List<Changelog> FindAll();

        Changelog Update(Changelog changelog);

        void Delete(long id);

        bool Exists(long id);

    }
}
