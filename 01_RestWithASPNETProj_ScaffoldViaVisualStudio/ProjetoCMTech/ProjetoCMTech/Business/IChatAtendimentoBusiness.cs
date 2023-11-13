using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IChatAtendimentoBusiness
    {
        ChatAtendimentoVO Create(ChatAtendimentoVO chatatendimento);

        ChatAtendimentoVO FindByID(long id);
        List<ChatAtendimentoVO> FindAll();

        ChatAtendimentoVO Update(ChatAtendimentoVO chatatendimento);

        void Delete(long id);

    }
}
