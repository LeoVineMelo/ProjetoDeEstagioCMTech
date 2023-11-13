using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IStatusAtendimentoBusiness
    {
        StatusAtendimentoVO Create(StatusAtendimentoVO statusatendimento);

        StatusAtendimentoVO FindByID(long id);
        List<StatusAtendimentoVO> FindAll();

        StatusAtendimentoVO Update(StatusAtendimentoVO statusatendimento);

        void Delete(long id);

    }
}
