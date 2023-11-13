using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class OrganizacaoRepositoryImplemetation : IOrganizacaoRepository
    {
        private PostgreSQLContext _context;

        public OrganizacaoRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<Organizacao> FindAll()
        {
           
            return _context.Organizacaos.ToList();
        }



        public Organizacao FindByID(long id) => _context.Organizacaos.SingleOrDefault(p => p.Id.Equals(id));

        public Organizacao Create(Organizacao organizacao)
        {
            try
            {
                _context.Add(organizacao);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return organizacao;
        }
       public Organizacao Update(Organizacao organizacao)
        {
            if(!Exists(organizacao.Id)) return null;

            var result = _context.Organizacaos.FirstOrDefault(p => p.Id.Equals(organizacao.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(organizacao);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return organizacao;
        }
        public void Delete(long id)
        {
            var result = _context.Organizacaos.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Organizacaos.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

 
 

        public bool Exists(long id)
        {
            return _context.Organizacaos.Any(p => p.Id.Equals(id));
        }
    }
}
