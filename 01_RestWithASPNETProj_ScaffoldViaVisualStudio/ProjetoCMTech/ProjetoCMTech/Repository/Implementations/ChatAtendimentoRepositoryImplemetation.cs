using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class ChatAtendimentoRepositoryImplemetation : IChatAtendimentoRepository
    {
        private PostgreSQLContext _context;

        public ChatAtendimentoRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<ChatAtendimento> FindAll()
        {
           
            return _context.ChatAtendimentos.ToList();
        }



        public ChatAtendimento FindByID(long id) => _context.ChatAtendimentos.SingleOrDefault(p => p.Id.Equals(id));

        public ChatAtendimento Create(ChatAtendimento chatatendimento)
        {
            try
            {
                _context.Add(chatatendimento);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return chatatendimento;
        }
       public ChatAtendimento Update(ChatAtendimento chatatendimento)
        {
            if(!Exists(chatatendimento.Id)) return null;

            var result = _context.ChatAtendimentos.FirstOrDefault(p => p.Id.Equals(chatatendimento.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(chatatendimento);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return chatatendimento;
        }
        public void Delete(long id)
        {
            var result = _context.ChatAtendimentos.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.ChatAtendimentos.Remove(result);
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
            return _context.ChatAtendimentos.Any(p => p.Id.Equals(id));
        }
    }
}
