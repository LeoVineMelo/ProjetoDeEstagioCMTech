using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{

    public class OrganizacaoVO
    {

        public long Id { get; set; }

        public long SegmentoId { get; set; }
        public SegmentoVO Segmento { get; set; }

        public long GrupoId { get; set; }
        public GrupoVO Grupo { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }
       
    }
}
