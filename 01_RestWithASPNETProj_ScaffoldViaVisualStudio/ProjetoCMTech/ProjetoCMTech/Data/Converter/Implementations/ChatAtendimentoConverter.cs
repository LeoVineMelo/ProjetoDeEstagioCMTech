using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class ChatAtendimentoConverter : IParser<ChatAtendimentoVO, ChatAtendimento>, IParser<ChatAtendimento, ChatAtendimentoVO>
    {
        private readonly AtendimentoConverter _atendimentoConverter;
        private readonly UsuarioConverter _usuarioConverter;


        public ChatAtendimentoConverter()
        {
            _atendimentoConverter = new AtendimentoConverter();
            _usuarioConverter = new UsuarioConverter();

        }

        public ChatAtendimento Parse(ChatAtendimentoVO origin)
        {
            if (origin == null) return null;
            return new ChatAtendimento
            {
                Id = origin.Id,
                AtendimentoId = origin.AtendimentoId,
                Atendimento = _atendimentoConverter.Parse(origin.Atendimento),
                RemetenteId = origin.RemetenteId,
                Remetente = _usuarioConverter.Parse(origin.Remetente),
                DestinatarioId = origin.DestinatarioId,
                Destinatario = _usuarioConverter.Parse(origin.Destinatario),
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
                Atendimento = _atendimentoConverter.Parse(origin.Atendimento),
                RemetenteId = origin.RemetenteId,
                Remetente = _usuarioConverter.Parse(origin.Remetente),
                DestinatarioId = origin.DestinatarioId,
                Destinatario = _usuarioConverter.Parse(origin.Destinatario),
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
