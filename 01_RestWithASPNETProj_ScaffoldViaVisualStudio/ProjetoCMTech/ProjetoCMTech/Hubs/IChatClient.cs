using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using System.Reflection.Emit;

namespace ProjetoCMTech.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatAtendimentoVO message);
    }

}
