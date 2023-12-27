using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    
    public class Segmento
    {


        public long Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Organizacao> Organizacaos { get; set; }

    }
}
