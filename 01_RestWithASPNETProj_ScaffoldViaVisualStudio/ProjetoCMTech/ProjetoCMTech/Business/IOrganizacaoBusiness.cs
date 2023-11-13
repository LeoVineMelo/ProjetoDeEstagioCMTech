using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IOrganizacaoBusiness
    {
        OrganizacaoVO Create(OrganizacaoVO organizacao);

        OrganizacaoVO FindByID(long id);
        List<OrganizacaoVO> FindAll();

        OrganizacaoVO Update(OrganizacaoVO organizacao);

        void Delete(long id);

    }
}
