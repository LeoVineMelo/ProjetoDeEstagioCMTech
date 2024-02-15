using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IAtendimentoBusiness
    {
        AtendimentoVO Create(AtendimentoVO atendimento);

        AtendimentoVO FindByID(long id);
        List<AtendimentoVO> FindAll(AtendimentoPesquisaVO pesquisa = null);
        int FindAllCount(AtendimentoPesquisaVO pesquisa = null);

        AtendimentoVO Update(AtendimentoVO atendimento);

        void Delete(long id);

    }
}
