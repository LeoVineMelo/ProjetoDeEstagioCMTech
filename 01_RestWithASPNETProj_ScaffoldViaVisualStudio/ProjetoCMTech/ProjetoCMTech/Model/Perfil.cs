using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    
    public class Perfil
    {


        public long Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }


    }
}
