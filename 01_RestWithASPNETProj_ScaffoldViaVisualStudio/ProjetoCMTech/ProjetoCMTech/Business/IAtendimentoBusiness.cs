using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IAtendimentoBusiness
    {
        AtendimentoVO Create(AtendimentoVO atendimento);

        AtendimentoVO FindByID(long id);
        List<AtendimentoVO> FindAll();

        AtendimentoVO Update(AtendimentoVO atendimento);

        void Delete(long id);

    }
}
