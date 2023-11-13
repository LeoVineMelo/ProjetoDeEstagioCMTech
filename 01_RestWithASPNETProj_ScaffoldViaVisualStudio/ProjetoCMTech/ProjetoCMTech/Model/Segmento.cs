using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    [Table("segmento")]
    public class Segmento
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }

    }
}
