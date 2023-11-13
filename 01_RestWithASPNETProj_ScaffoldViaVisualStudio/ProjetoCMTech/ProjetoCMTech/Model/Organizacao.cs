using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    [Table("organizacao")]
    public class Organizacao
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("segmento_id")]
        public int SegmentoId { get; set; }
        [Column("grupo_id")]
        public string GrupoId { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("telefone")]
        public string Telefone { get; set; }
       
    }
}
