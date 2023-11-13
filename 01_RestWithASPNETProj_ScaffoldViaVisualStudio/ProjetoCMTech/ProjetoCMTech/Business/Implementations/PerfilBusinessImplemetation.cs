using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;

namespace ProjetoCMTech.Business.Implementations
{
    public class PerfilBusinessImplemetation : IPerfilBusiness
    {
        private readonly IPerfilRepository _repository;

        private readonly PerfilCoverter _coverter;

        public PerfilBusinessImplemetation(IPerfilRepository repository)
        {
            _repository = repository;

            _coverter = new PerfilCoverter();
        }
       public List<PerfilVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public PerfilVO FindByID(long id) => _coverter.Parse(_repository.FindByID(id));

        public PerfilVO Create(PerfilVO perfil)
        {

            var perfilEntity = _coverter.Parse(perfil);
            perfilEntity = _repository.Create(perfilEntity);
            return _coverter.Parse(perfilEntity);
        }
       public PerfilVO Update(PerfilVO perfil)
        {
            var perfilEntity = _coverter.Parse(perfil);
            perfilEntity = _repository.Update(perfilEntity);
            return _coverter.Parse(perfilEntity);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
