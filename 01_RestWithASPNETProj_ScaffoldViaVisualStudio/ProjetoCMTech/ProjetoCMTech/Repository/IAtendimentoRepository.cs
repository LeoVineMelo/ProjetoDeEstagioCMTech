using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IAtendimentoRepository
    {
        Atendimento Create(Atendimento atendimento);

        Atendimento FindByID(long id);
        List<Atendimento> FindAll(AtendimentoPesquisaVO pesquisa = null);

        int FindAllCount(AtendimentoPesquisaVO pesquisa = null);

        Atendimento Update(Atendimento atendimento);

        void Delete(long id);

        bool Exists(long id);

    }
}
