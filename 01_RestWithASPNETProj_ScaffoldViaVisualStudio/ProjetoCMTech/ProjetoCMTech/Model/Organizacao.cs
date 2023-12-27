using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
   
    public class Organizacao
    {


        public long Id { get; set; }
        [ForeignKey("Segmento")]

        public long SegmentoId { get; set; }
        public Segmento Segmento { get; set; }
        [ForeignKey("Grupo")]

        public long GrupoId { get; set; }
        public Grupo Grupo { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public IEnumerable<Atendimento> Atendimentos { get; set; }

        public IEnumerable<Departamento> Departamentos { get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }


    }
}
