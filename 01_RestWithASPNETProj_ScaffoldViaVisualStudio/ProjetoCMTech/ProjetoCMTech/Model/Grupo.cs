using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    [Table("grupo")]
    public class Grupo
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }

    }
}
