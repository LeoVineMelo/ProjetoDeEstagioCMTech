using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;

namespace ProjetoCMTech.Business.Implementations
{
    public class ChangelogBusinessImplemetation : IChangelogBusiness
    {
        private readonly IChangelogRepository _repository;

        private readonly ChangelogCoverter _coverter;
        public ChangelogBusinessImplemetation(IChangelogRepository repository)
        {
            _repository = repository;
            _coverter = new ChangelogCoverter();
        }
       public List<ChangelogVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public ChangelogVO FindByID(long id) => _coverter.Parse(_repository.FindByID(id));

        public ChangelogVO Create(ChangelogVO changelog)
        {


            var changelogEntity = _coverter.Parse(changelog);
            changelogEntity = _repository.Create(changelogEntity);
            return _coverter.Parse(changelogEntity);
        }
       public ChangelogVO Update(ChangelogVO changelog)
        {

            var changelogEntity = _coverter.Parse(changelog);
            changelogEntity = _repository.Update(changelogEntity);
            return _coverter.Parse(changelogEntity);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
