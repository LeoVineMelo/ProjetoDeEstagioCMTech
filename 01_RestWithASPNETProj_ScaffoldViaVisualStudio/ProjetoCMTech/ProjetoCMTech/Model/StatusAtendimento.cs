using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
  
    public class StatusAtendimento
    {

   
        public long Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Atendimento> Atendimentos { get; set; }

    }
}
