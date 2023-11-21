using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
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
       public List<Usuario> FindAll()
        {
           
            return _context.Usuarios.ToList();
        }



        public Usuario FindByID(long id) => _context.Usuarios.SingleOrDefault(p => p.Id.Equals(id));

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

        public Usuario ValidateCredentials(UsuarioVO usuario)
        {
            var chave = Encoding.UTF8.GetBytes("safmnbasjkf15132");
            var pass = ComputeHash(usuario.Senha, algorithm:new HMACMD5(chave));
            return _context.Usuarios.FirstOrDefault(u => (u.Email == usuario.Email) && (u.Senha ==  pass));
        }

        private string ComputeHash(string input, HMACMD5 algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }


    }
}
