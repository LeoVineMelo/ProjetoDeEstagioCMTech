using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;

namespace ProjetoCMTech.Business.Implementations
{
    public class DepartamentoBusinessImplemetation : IDepartamentoBusiness
    {
        private readonly IDepartamentoRepository _repository;

        private readonly DepartamentoCoverter _coverter;

        public DepartamentoBusinessImplemetation(IDepartamentoRepository repository)
        {
            _repository = repository;
            _coverter = new DepartamentoCoverter();
        }
       public List<DepartamentoVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public DepartamentoVO FindByID(long id) => _coverter.Parse(_repository.FindByID(id));

        public DepartamentoVO Create(DepartamentoVO departamento)
        {

            var departamentoEntity = _coverter.Parse(departamento);
            departamentoEntity = _repository.Create(departamentoEntity);
            return _coverter.Parse(departamentoEntity);
        }
       public DepartamentoVO Update(DepartamentoVO departamento)
        {
            var departamentoEntity = _coverter.Parse(departamento);
            departamentoEntity = _repository.Update(departamentoEntity);
            return _coverter.Parse(departamentoEntity);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
