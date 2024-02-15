using Microsoft.IdentityModel.Protocols.WSTrust;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IStatusUsuarioRepository
    {

        StatusUsuario Create(StatusUsuario statusUsuario);

        StatusUsuario FindByID(long id);
        List<StatusUsuario> FindAll();

        StatusUsuario Update(StatusUsuario statusUsuario);

        void Delete(long id);
        
        
    }
}
