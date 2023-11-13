using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;

namespace ProjetoCMTech.Business.Implementations
{
    public class ChatAtendimentoBusinessImplemetation : IChatAtendimentoBusiness
    {
        private readonly IChatAtendimentoRepository _repository;

        private readonly ChatAtendimentoCoverter _coverter;

        public ChatAtendimentoBusinessImplemetation(IChatAtendimentoRepository repository)
        {
            _repository = repository;
            _coverter = new ChatAtendimentoCoverter();
        }
       public List<ChatAtendimentoVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public ChatAtendimentoVO FindByID(long id) => _coverter.Parse(_repository.FindByID(id));

        public ChatAtendimentoVO Create(ChatAtendimentoVO chatatendimento)
        {

            var chatatendimentoEntity = _coverter.Parse(chatatendimento);
            chatatendimentoEntity = _repository.Create(chatatendimentoEntity);
            return _coverter.Parse(chatatendimentoEntity);
        }
       public ChatAtendimentoVO Update(ChatAtendimentoVO chatatendimento)
        {
            var chatatendimentoEntity = _coverter.Parse(chatatendimento);
            chatatendimentoEntity = _repository.Update(chatatendimentoEntity);
            return _coverter.Parse(chatatendimentoEntity); ;
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
