using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    [Table("departamento")]
    public class Departamento
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("organizacao_id")]
        public long OrganizacaoId { get; set; }
        [Column("nome")]
        public string Nome { get; set; }

    }
}
