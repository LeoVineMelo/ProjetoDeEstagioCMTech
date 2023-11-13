using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;

namespace ProjetoCMTech.Business.Implementations
{
    public class GrupoBusinessImplemetation : IGrupoBusiness
    {
        private readonly IGrupoRepository _repository;

        private readonly GrupoCoverter _coverter;

        public GrupoBusinessImplemetation(IGrupoRepository repository)
        {
            _repository = repository;
            _coverter = new GrupoCoverter();
        }
       public List<GrupoVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public GrupoVO FindByID(long id) => _coverter.Parse(_repository.FindByID(id));

        public GrupoVO Create(GrupoVO grupo)
        {

            var grupoEntity = _coverter.Parse(grupo);
            grupoEntity = _repository.Create(grupoEntity);
            return _coverter.Parse(grupoEntity);
        }
       public GrupoVO Update(GrupoVO grupo)
        {
            var grupoEntity = _coverter.Parse(grupo);
            grupoEntity = _repository.Update(grupoEntity);
            return _coverter.Parse(grupoEntity);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
