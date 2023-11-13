using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;

namespace ProjetoCMTech.Business.Implementations
{
    public class StatusAtendimentoBusinessImplemetation : IStatusAtendimentoBusiness
    {
        private readonly IStatusAtendimentoRepository _repository;

        private readonly StatusAtendimentoCoverter _coverter;
        public StatusAtendimentoBusinessImplemetation(IStatusAtendimentoRepository repository)
        {
            _repository = repository;
            _coverter = new StatusAtendimentoCoverter();
        }
       public List<StatusAtendimentoVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public StatusAtendimentoVO FindByID(long id) => _coverter.Parse(_repository.FindByID(id));

        public StatusAtendimentoVO Create(StatusAtendimentoVO statusatendimento)
        {

            var statusatendimentoEntity = _coverter.Parse(statusatendimento);
            statusatendimentoEntity = _repository.Create(statusatendimentoEntity);
            return _coverter.Parse(statusatendimentoEntity);
        }
       public StatusAtendimentoVO Update(StatusAtendimentoVO statusatendimento)
        {
            var statusatendimentoEntity = _coverter.Parse(statusatendimento);
            statusatendimentoEntity = _repository.Update(statusatendimentoEntity);
            return _coverter.Parse(statusatendimentoEntity);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
