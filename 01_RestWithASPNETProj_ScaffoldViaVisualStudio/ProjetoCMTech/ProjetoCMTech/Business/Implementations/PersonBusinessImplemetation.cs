using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;

namespace ProjetoCMTech.Business.Implementations
{
    public class PersonBusinessImplemetation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        private readonly PersonCoverter _coverter;

        public PersonBusinessImplemetation(IPersonRepository repository)
        {
            _repository = repository;
            _coverter = new PersonCoverter();
        }
       public List<PersonVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public PersonVO FindByID(long id) => _coverter.Parse( _repository.FindByID(id));

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _coverter.Parse(person );
            personEntity = _repository.Create(personEntity);
            return _coverter.Parse(personEntity );
            
        }
       public PersonVO Update(PersonVO person)
        {
            var personEntity = _coverter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _coverter.Parse(personEntity);

        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
