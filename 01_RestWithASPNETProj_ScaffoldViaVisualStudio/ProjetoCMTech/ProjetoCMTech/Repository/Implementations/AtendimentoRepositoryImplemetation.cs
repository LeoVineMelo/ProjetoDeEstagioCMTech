using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class AtendimentoRepositoryImplemetation : IAtendimentoRepository
    {
        private PostgreSQLContext _context;

        public AtendimentoRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<Atendimento> FindAll()
        {
           
            return _context.Atendimentos.ToList();
        }



        public Atendimento FindByID(long id) => _context.Atendimentos.SingleOrDefault(p => p.Id.Equals(id));

        public Atendimento Create(Atendimento atendimento)
        {
            try
            {
                _context.Add(atendimento);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return atendimento;
        }
       public Atendimento Update(Atendimento atendimento)
        {
            if(!Exists(atendimento.Id)) return null;

            var result = _context.Atendimentos.FirstOrDefault(p => p.Id.Equals(atendimento.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(atendimento);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return atendimento;
        }
        public void Delete(long id)
        {
            var result = _context.Atendimentos.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Atendimentos.Remove(result);
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
            return _context.Atendimentos.Any(p => p.Id.Equals(id));
        }
    }
}
