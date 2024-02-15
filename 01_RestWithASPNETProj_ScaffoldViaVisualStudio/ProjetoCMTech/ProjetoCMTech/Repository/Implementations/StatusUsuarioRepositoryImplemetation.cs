using Microsoft.EntityFrameworkCore;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class StatusUsuarioRepositoryImplemetation : IStatusUsuarioRepository
    {
        private PostgreSQLContext _context;

        public StatusUsuarioRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
        public List<StatusUsuario>FindAll()
        {
           
            return _context.StatusUsuarios.ToList();
                
        }



         public StatusUsuario FindByID(long id)
        {
            return _context.StatusUsuarios.SingleOrDefault(p => p.UsuarioId.Equals(id));
        }

         public StatusUsuario Create(StatusUsuario statusUsuario)
        {
            try
            {
                _context.Add(statusUsuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return statusUsuario;
        }
         public StatusUsuario Update(StatusUsuario statusUsuario)
        {
            if(!Exists(statusUsuario.UsuarioId)) return null;

            var result = _context.StatusUsuarios.FirstOrDefault(p => p.UsuarioId.Equals(statusUsuario.UsuarioId));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(statusUsuario);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return statusUsuario;
        }
         public void Delete(long id)
        {
            var result = _context.StatusUsuarios.FirstOrDefault(p => p.UsuarioId.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.StatusUsuarios.Remove(result);
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
            return _context.StatusUsuarios.Any(p => p.UsuarioId.Equals(id));
        }


        
    }
    
}
