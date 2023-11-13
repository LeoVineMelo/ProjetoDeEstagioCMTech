using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class PerfilRepositoryImplemetation : IPerfilRepository
    {
        private PostgreSQLContext _context;

        public PerfilRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<Perfil> FindAll()
        {
           
            return _context.Perfils.ToList();
        }



        public Perfil FindByID(long id) => _context.Perfils.SingleOrDefault(p => p.Id.Equals(id));

        public Perfil Create(Perfil perfil)
        {
            try
            {
                _context.Add(perfil);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return perfil;
        }
       public Perfil Update(Perfil perfil)
        {
            if(!Exists(perfil.Id)) return null;

            var result = _context.Perfils.FirstOrDefault(p => p.Id.Equals(perfil.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(perfil);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return perfil;
        }
        public void Delete(long id)
        {
            var result = _context.Perfils.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Perfils.Remove(result);
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
            return _context.Perfils.Any(p => p.Id.Equals(id));
        }
    }
}
