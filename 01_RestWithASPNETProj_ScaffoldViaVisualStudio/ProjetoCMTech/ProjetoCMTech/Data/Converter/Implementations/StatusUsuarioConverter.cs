using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class StatusUsuarioConverter : IParser<StatusUsuarioVO, StatusUsuario>, IParser<StatusUsuario, StatusUsuarioVO>
    {

        public StatusUsuario Parse(StatusUsuarioVO origin)
        {
            if (origin == null) return null;
            return new StatusUsuario
            {
                UsuarioId = origin.UsuarioId,
                

            };
        }
        public StatusUsuarioVO Parse(StatusUsuario origin)
        {
            if (origin == null) return null;
            return new StatusUsuarioVO
            {
                UsuarioId = (int)origin.UsuarioId,
                
            };
        }

        public List<StatusUsuarioVO> Parse(List<StatusUsuario> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<StatusUsuario> Parse(List<StatusUsuarioVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
