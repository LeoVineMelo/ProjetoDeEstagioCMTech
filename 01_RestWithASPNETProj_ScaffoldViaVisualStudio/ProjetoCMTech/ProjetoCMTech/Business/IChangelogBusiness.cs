using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IChangelogBusiness
    {
        ChangelogVO Create(ChangelogVO changelog);

        ChangelogVO FindByID(long id);
        List<ChangelogVO> FindAll();

        ChangelogVO Update(ChangelogVO changelog);

        void Delete(long id);

    }
}
