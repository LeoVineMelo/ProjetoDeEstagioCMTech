using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class StatusAtendimentoRepositoryImplemetation : IStatusAtendimentoRepository
    {
        private PostgreSQLContext _context;

        public StatusAtendimentoRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<StatusAtendimento> FindAll()
        {
           
            return _context.StatusAtendimentos.ToList();
        }



        public StatusAtendimento FindByID(long id) => _context.StatusAtendimentos.SingleOrDefault(p => p.Id.Equals(id));

        public StatusAtendimento Create(StatusAtendimento statusAtendimento)
        {
            try
            {
                _context.Add(statusAtendimento);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return statusAtendimento;
        }
       public StatusAtendimento Update(StatusAtendimento statusAtendimento)
        {
            if(!Exists(statusAtendimento.Id)) return null;

            var result = _context.StatusAtendimentos.FirstOrDefault(p => p.Id.Equals(statusAtendimento.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(statusAtendimento);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return statusAtendimento;
        }
        public void Delete(long id)
        {
            var result = _context.StatusAtendimentos.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.StatusAtendimentos.Remove(result);
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
            return _context.StatusAtendimentos.Any(p => p.Id.Equals(id));
        }
    }
}
