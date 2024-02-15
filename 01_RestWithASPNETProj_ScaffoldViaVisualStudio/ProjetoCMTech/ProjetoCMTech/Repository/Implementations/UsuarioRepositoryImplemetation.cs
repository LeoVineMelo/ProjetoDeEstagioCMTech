using Microsoft.EntityFrameworkCore;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoCMTech.Repository.Implementations
{
    public class UsuarioRepositoryImplemetation : IUsuarioRepository
    {
        private readonly PostgreSQLContext _context;

        public UsuarioRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<Usuario> FindAll(UserPesquisaVO pesquisa = null)
        {

            var list = _context.Usuarios
                .Include(x => x.Perfil)
                .Include(x => x.Departamento)
                .Include(x => x.Organizacao)
                .AsQueryable();

            list = FindAllFilter(list, pesquisa);

            return list.ToList();
        }

        public int FindAllCount(UserPesquisaVO pesquisa = null)
        {

            var list = _context.Usuarios
                .Include(x => x.Perfil)
                .Include(x => x.Departamento)
                .Include(x => x.Organizacao)
                .AsQueryable();

            list = FindAllFilter(list, pesquisa);
            return list.Count();
        }
         private IQueryable<Usuario> FindAllFilter(IQueryable<Usuario> list, UserPesquisaVO pesquisa)
        {
            if (pesquisa != null)
            {
                if (!string.IsNullOrEmpty(pesquisa.Nome))
                    list = list.Where(x => EF.Functions.Like(x.Nome.Trim().ToLower(), $"%{pesquisa.Nome.Trim().ToLower()}%"));
                if (!string.IsNullOrEmpty(pesquisa.Cargo))
                    list = list.Where(x => EF.Functions.Like(x.Perfil.Nome.Trim().ToLower(), $"%{pesquisa.Cargo.Trim().ToLower()}%"));
                if (!string.IsNullOrEmpty(pesquisa.Setor))
                    list = list.Where(x => EF.Functions.Like(x.Departamento.Nome.Trim().ToLower(), $"%{pesquisa.Setor.Trim().ToLower()}%"));
            }
            return list;
        }


        public Usuario FindByID(long id)
        {
            return _context.Usuarios
                .Include(x => x.Perfil)
                .Include(x => x.Departamento)
                .Include(x => x.Organizacao)
                .SingleOrDefault(p => p.Id.Equals(id));
        }

        public Usuario Create(Usuario usuario)
        {
            try
            {
                var chave = Encoding.UTF8.GetBytes("safmnbasjkf15132");
                usuario.Senha = ComputeHash(usuario.Senha, algorithm: new HMACMD5(chave));
                _context.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }
       public Usuario Update(Usuario usuario)
        {
            if(!Exists(usuario.Id)) return null;

            var result = _context.Usuarios.FirstOrDefault(p => p.Id.Equals(usuario.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(usuario);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return usuario;
        }
        public void Delete(long id)
        {
            var result = _context.Usuarios.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Usuarios.Remove(result);
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
            return _context.Usuarios.Any(p => p.Id.Equals(id));
        }

        public Usuario ValidateCredentials(UsuarioLoginVO usuario)
        {
            var chave = Encoding.UTF8.GetBytes("safmnbasjkf15132");
            var pass = ComputeHash(usuario.Senha, algorithm:new HMACMD5(chave));
            return _context.Usuarios.IgnoreAutoIncludes().Include(x=>x.Perfil).FirstOrDefault(u => (u.Email == usuario.Email) && (u.Senha == pass));
        }

        private string ComputeHash(string input, HMACMD5 algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }


    }
}
