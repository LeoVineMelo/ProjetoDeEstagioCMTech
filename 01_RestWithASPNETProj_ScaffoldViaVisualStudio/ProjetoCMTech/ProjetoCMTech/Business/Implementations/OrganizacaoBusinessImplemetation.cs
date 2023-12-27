using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Repository;
using System;
using System.Text.RegularExpressions;

namespace ProjetoCMTech.Business.Implementations
{
    public class OrganizacaoBusinessImplemetation : IOrganizacaoBusiness
    {
        private readonly IOrganizacaoRepository _repository;

        private readonly OrganizacaoConverter _coverter;

        public OrganizacaoBusinessImplemetation(IOrganizacaoRepository repository)
        {
            _repository = repository;

            _coverter = new OrganizacaoConverter();
        }
       public List<OrganizacaoVO> FindAll()
        {

            return _coverter.Parse(_repository.FindAll());
        }

        public OrganizacaoVO FindByID(long id) => _coverter.Parse(_repository.FindByID(id));

        public OrganizacaoVO Create(OrganizacaoVO organizacao)
        {

            var organizacaoEntity = _coverter.Parse(organizacao);
            organizacaoEntity = _repository.Create(organizacaoEntity);
            return _coverter.Parse(organizacaoEntity);
        }
       public OrganizacaoVO Update(OrganizacaoVO organizacao)
        {
            var organizacaoEntity = _coverter.Parse(organizacao);
            organizacaoEntity = _repository.Create(organizacaoEntity);
            return _coverter.Parse(organizacaoEntity);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
