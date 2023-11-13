using Microsoft.EntityFrameworkCore;

namespace ProjetoCMTech.Model.Context
{
    public class PostgreSQLContext:DbContext
    {
        public PostgreSQLContext()
        {

        }
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<ChatAtendimento> ChatAtendimentos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Organizacao> Organizacaos { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<StatusAtendimento> StatusAtendimentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Changelog> Changelogs { get; set; }

    }
}
