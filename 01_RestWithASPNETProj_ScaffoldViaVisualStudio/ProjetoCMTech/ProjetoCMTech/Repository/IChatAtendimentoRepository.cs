using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IChatAtendimentoRepository
    {
        ChatAtendimento Create(ChatAtendimento chatatendimento);

        ChatAtendimento FindByID(long id);
        List<ChatAtendimento> FindAll();

        ChatAtendimento Update(ChatAtendimento chatatendimento);

        void Delete(long id);

        bool Exists(long id);

    }
}
