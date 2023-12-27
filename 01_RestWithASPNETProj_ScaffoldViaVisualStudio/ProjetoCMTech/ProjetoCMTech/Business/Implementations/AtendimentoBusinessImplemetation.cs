using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;

namespace ProjetoCMTech.Business.Implementations
{
    public class AtendimentoBusinessImplemetation : IAtendimentoBusiness
    {
        private readonly IAtendimentoRepository _repository;

        private readonly AtendimentoConverter _coverter;

        public AtendimentoBusinessImplemetation(IAtendimentoRepository repository)
        {
            _repository = repository;
            _coverter = new AtendimentoConverter();
        }
       public List<AtendimentoVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public AtendimentoVO FindByID(long id) => _coverter.Parse(_repository.FindByID(id));

        public AtendimentoVO Create(AtendimentoVO atendimento)
        {

            var atendimentoEntity = _coverter.Parse(atendimento);
            atendimentoEntity = _repository.Create(atendimentoEntity);
            return _coverter.Parse(atendimentoEntity);
        }
       public AtendimentoVO Update(AtendimentoVO atendimento)
        {
            var atendimentoEntity = _coverter.Parse(atendimento);
            atendimentoEntity = _repository.Update(atendimentoEntity);
            return _coverter.Parse(atendimentoEntity);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
