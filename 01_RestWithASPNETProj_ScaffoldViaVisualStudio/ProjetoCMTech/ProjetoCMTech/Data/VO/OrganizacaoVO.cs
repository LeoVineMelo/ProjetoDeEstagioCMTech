using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{

    public class OrganizacaoVO
    {

        public long Id { get; set; }

        public int SegmentoId { get; set; }

        public string GrupoId { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }
       
    }
}
