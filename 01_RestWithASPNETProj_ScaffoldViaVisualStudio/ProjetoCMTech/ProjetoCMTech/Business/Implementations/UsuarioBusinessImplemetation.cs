using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;

namespace ProjetoCMTech.Business.Implementations
{
    public class UsuarioBusinessImplemetation : IUsuarioBusiness
    {
        private readonly IUsuarioRepository _repository;

        private readonly UsuarioCoverter _coverter;

        public UsuarioBusinessImplemetation(IUsuarioRepository repository)
        {
            _repository = repository;
            _coverter = new UsuarioCoverter();
        }
       public List<UsuarioVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public UsuarioVO FindByID(long id) => _coverter.Parse(_repository.FindByID(id));

        public UsuarioVO Create(UsuarioVO usuario)
        {

            var usuarioEntity = _coverter.Parse(usuario);
            usuarioEntity = _repository.Create(usuarioEntity);
            return _coverter.Parse(usuarioEntity);
        }
       public UsuarioVO Update(UsuarioVO usuario)
        {
            var usuarioEntity = _coverter.Parse(usuario);
            usuarioEntity = _repository.Update(usuarioEntity);
            return _coverter.Parse(usuarioEntity);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
