using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IOrganizacaoRepository
    {
        Organizacao Create(Organizacao organizacao);

        Organizacao FindByID(long id);
        List<Organizacao> FindAll();

        Organizacao Update(Organizacao organizacao);

        void Delete(long id);

        bool Exists(long id);

    }
}
