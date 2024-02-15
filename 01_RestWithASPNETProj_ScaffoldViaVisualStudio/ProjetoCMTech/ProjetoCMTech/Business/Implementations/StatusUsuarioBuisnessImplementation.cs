using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using ProjetoCMTech.Repository;

namespace ProjetoCMTech.Business.Implementations
{
    public class StatusUsuarioBuisnessImplementation
    {
        private readonly IStatusUsuarioRepository _repository;

        private readonly StatusUsuarioConverter _converter;

        public StatusUsuarioBuisnessImplementation(IStatusUsuarioRepository repository)
        {
            _repository = repository;
            _converter = new StatusUsuarioConverter();
        }
        public List<StatusUsuarioVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        public StatusUsuarioVO FindById(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
        public StatusUsuarioVO Create(StatusUsuarioVO statusUsuario)
        {
            var statusUsuarioEntity = _converter.Parse(statusUsuario);
            statusUsuarioEntity = _repository.Create(statusUsuarioEntity);
            return _converter.Parse(statusUsuarioEntity);
        }
        public StatusUsuarioVO Update(StatusUsuarioVO statusUsuario)
        {
            var statusUsuarioEntity = _converter.Parse(statusUsuario);
            statusUsuarioEntity = _repository.Update(statusUsuarioEntity);
            return _converter.Parse(statusUsuarioEntity);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
