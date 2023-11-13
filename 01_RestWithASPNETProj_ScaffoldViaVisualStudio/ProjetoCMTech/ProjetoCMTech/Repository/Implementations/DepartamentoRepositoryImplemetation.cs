using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class DepartamentoRepositoryImplemetation : IDepartamentoRepository
    {
        private PostgreSQLContext _context;

        public DepartamentoRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<Departamento> FindAll()
        {
           
            return _context.Departamentos.ToList();
        }



        public Departamento FindByID(long id) => _context.Departamentos.SingleOrDefault(p => p.Id.Equals(id));

        public Departamento Create(Departamento departamento)
        {
            try
            {
                _context.Add(departamento);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return departamento;
        }
       public Departamento Update(Departamento departamento)
        {
            if(!Exists(departamento.Id)) return null;

            var result = _context.Departamentos.FirstOrDefault(p => p.Id.Equals(departamento.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(departamento);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return departamento;
        }
        public void Delete(long id)
        {
            var result = _context.Departamentos.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Departamentos.Remove(result);
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
            return _context.Departamentos.Any(p => p.Id.Equals(id));
        }
    }
}
