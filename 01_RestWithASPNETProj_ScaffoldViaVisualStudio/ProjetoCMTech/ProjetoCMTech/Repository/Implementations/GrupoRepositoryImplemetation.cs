using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class GrupoRepositoryImplemetation : IGrupoRepository
    {
        private PostgreSQLContext _context;

        public GrupoRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<Grupo> FindAll()
        {
           
            return _context.Grupos.ToList();
        }



        public Grupo FindByID(long id) => _context.Grupos.SingleOrDefault(p => p.Id.Equals(id));

        public Grupo Create(Grupo grupo)
        {
            try
            {
                _context.Add(grupo);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return grupo;
        }
       public Grupo Update(Grupo grupo)
        {
            if(!Exists(grupo.Id)) return null;

            var result = _context.Grupos.FirstOrDefault(p => p.Id.Equals(grupo.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(grupo);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return grupo;
        }
        public void Delete(long id)
        {
            var result = _context.Grupos.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Grupos.Remove(result);
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
            return _context.Grupos.Any(p => p.Id.Equals(id));
        }
    }
}
