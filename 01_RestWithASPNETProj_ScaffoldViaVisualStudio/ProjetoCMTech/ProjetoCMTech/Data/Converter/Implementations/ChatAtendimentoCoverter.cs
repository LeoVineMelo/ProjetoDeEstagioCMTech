using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class ChatAtendimentoCoverter : IParser<ChatAtendimentoVO, ChatAtendimento>, IParser<ChatAtendimento, ChatAtendimentoVO>
    {
        public ChatAtendimento Parse(ChatAtendimentoVO origin)
        {
            if (origin == null) return null;
            return new ChatAtendimento
            {
                Id = origin.Id,
                AtendimentoId = origin.AtendimentoId,
                Rementente = origin.Rementente,
                Destinatario = origin.Destinatario,
                DataHora = origin.DataHora,
                Mensagem = origin.Mensagem,
            };
        }
        public ChatAtendimentoVO Parse(ChatAtendimento origin)
        {
            if (origin == null) return null;
            return new ChatAtendimentoVO
            {
                Id = origin.Id,
                AtendimentoId = origin.AtendimentoId,
                Rementente = origin.Rementente,
                Destinatario = origin.Destinatario,
                DataHora = origin.DataHora,
                Mensagem = origin.Mensagem,
            };
        }

        public List<ChatAtendimentoVO> Parse(List<ChatAtendimento> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<ChatAtendimento> Parse(List<ChatAtendimentoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
