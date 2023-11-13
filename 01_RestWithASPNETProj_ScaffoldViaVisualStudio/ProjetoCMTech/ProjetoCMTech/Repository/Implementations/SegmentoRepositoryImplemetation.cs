using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class SegmentoRepositoryImplemetation : ISegmentoRepository
    {
        private PostgreSQLContext _context;

        public SegmentoRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<Segmento> FindAll()
        {
           
            return _context.Segmentos.ToList();
        }



        public Segmento FindByID(long id) => _context.Segmentos.SingleOrDefault(p => p.Id.Equals(id));

        public Segmento Create(Segmento segmento)
        {
            try
            {
                _context.Add(segmento);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return segmento;
        }
       public Segmento Update(Segmento segmento)
        {
            if(!Exists(segmento.Id)) return null;

            var result = _context.Segmentos.FirstOrDefault(p => p.Id.Equals(segmento.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(segmento);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return segmento;
        }
        public void Delete(long id)
        {
            var result = _context.Segmentos.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Segmentos.Remove(result);
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
            return _context.Segmentos.Any(p => p.Id.Equals(id));
        }
    }
}
