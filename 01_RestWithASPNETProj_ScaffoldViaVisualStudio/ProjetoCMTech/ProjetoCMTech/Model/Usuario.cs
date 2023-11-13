using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCMTech.Model
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("departamento_id")]
        public int? DepartamentoId { get; set; }
        [Column("organizacao_id")]
        public int? OrganizacaoId { get; set; }
        [Column("perfil_id")]
        public int PerfilId { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
