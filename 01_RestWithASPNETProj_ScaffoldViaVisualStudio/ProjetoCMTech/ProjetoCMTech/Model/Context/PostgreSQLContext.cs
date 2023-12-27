using Microsoft.EntityFrameworkCore;
using ProjetoCMTech.Data.VO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjetoCMTech.Model.Context
{
    public class PostgreSQLContext:DbContext
    {
        public string ConnectionString = "PostgreeConnection:PostgreeConnectionString";
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
        public DbSet<Connection> Connection { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreSQLContext).Assembly);
            

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("nome");

                entity.ToTable("perfil");
            });
            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("nome");

                entity.ToTable("grupo");
            });
            modelBuilder.Entity<Segmento>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("nome");

                entity.ToTable("segmento");
            });
            modelBuilder.Entity<Organizacao>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.SegmentoId)
                   .HasColumnName("segmento_id");

                entity.Property(e => e.GrupoId)
                   .HasColumnName("grupo_id");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("nome");

                entity.Property(e => e.Telefone)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("telefone");

                entity.HasOne(e => e.Segmento)
                    .WithMany(e => e.Organizacaos)
                    .HasForeignKey(e => e.SegmentoId);

                entity.HasOne(e => e.Grupo)
                    .WithMany(e => e.Organizacaos)
                    .HasForeignKey(e => e.GrupoId);

                entity.ToTable("organizacao");
            });
            modelBuilder.Entity<StatusAtendimento>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("nome");

                entity.ToTable("status_atendimento");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.OrganizacaoId)
                   .HasColumnName("organizacao_id");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("nome");

                entity.HasOne(e => e.Organizacao)
                    .WithMany(e => e.Departamentos)
                    .HasForeignKey(e => e.OrganizacaoId);

                entity.ToTable("departamento");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.DepartamentoId)
                   .HasColumnName("departamento_id");

                entity.Property(e => e.OrganizacaoId)
                   .HasColumnName("organizacao_id");

                entity.Property(e => e.PerfilId)
                  .HasColumnName("perfil_id");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("nome");

                entity.Property(e => e.Email)
                   .HasColumnType("varchar(255)")
                   .HasColumnName("email");

                entity.Property(e => e.Senha)
                   .HasColumnType("varchar(255)")
                   .HasColumnName("senha");

                entity.Property(e => e.DataCadastro)
                   .HasColumnType("timestamp")
                   .HasColumnName("data_cadastro");

                entity.HasOne(e => e.Departamento)
                    .WithMany(e => e.Usuarios)
                    .HasForeignKey(e => e.DepartamentoId);

                entity.HasOne(e => e.Organizacao)
                    .WithMany(e => e.Usuarios)
                    .HasForeignKey(e => e.OrganizacaoId);

                entity.HasOne(e => e.Perfil)
                    .WithMany(e => e.Usuarios)
                    .HasForeignKey(e => e.PerfilId);

                entity.ToTable("usuario");
            });

            modelBuilder.Entity<Atendimento>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.StatusAtendimentoId)
                   .HasColumnName("status_atendimento_id");

                entity.Property(e => e.DepartamentoId)
                   .HasColumnName("departamento_id");

                entity.Property(e => e.UsuarioId)
                  .HasColumnName("usuario_id");

                entity.Property(e => e.ClienteId)
                 .HasColumnName("cliente_id");

                entity.Property(e => e.OrganizacaoId)
                 .HasColumnName("organizacao_id");

                entity.Property(e => e.DataHoraAtendimento)
                   .HasColumnType("timestamp")
                   .HasColumnName("data_hora_atendimento");

                entity.HasOne(e => e.StatusAtendimento)
                    .WithMany(e => e.Atendimentos)
                    .HasForeignKey(e => e.StatusAtendimentoId);

                entity.HasOne(e => e.Departamento)
                    .WithMany(e => e.Atendimentos)
                    .HasForeignKey(e => e.DepartamentoId);

                entity.HasOne(e => e.Usuario)
                    .WithMany(e => e.Atendimentos)
                    .HasForeignKey(e => e.UsuarioId);

                entity.HasOne(e => e.Cliente)
                    .WithMany(e => e.AtendimentosClientes)
                    .HasForeignKey(e => e.ClienteId);

                entity.HasOne(e => e.Organizacao)
                    .WithMany(e => e.Atendimentos)
                    .HasForeignKey(e => e.OrganizacaoId);

                entity.ToTable("atendimento");
            });

            modelBuilder.Entity<ChatAtendimento>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.AtendimentoId)
                   .HasColumnName("atendimento_id");

                entity.Property(e => e.RemetenteId)
                   .HasColumnName("remetente_id");

                entity.Property(e => e.DestinatarioId)
                  .HasColumnName("destinatario_id");

                entity.Property(e => e.DataHora)
                   .HasColumnType("timestamp")
                   .HasColumnName("data_hora");

                entity.Property(e => e.Mensagem)
                    .HasColumnType("text")
                    .HasColumnName("messagem");

                entity.HasOne(e => e.Atendimento)
                    .WithMany(e => e.ChatAtendimentos)
                    .HasForeignKey(e => e.AtendimentoId);

                entity.HasOne(e => e.Remetente)
                    .WithMany(e => e.ChatAtendimentoRemetentes)
                    .HasForeignKey(e => e.RemetenteId);

                entity.HasOne(e => e.Destinatario)
                    .WithMany(e => e.ChatAtendimentoDestinatarios)
                    .HasForeignKey(e => e.DestinatarioId);

                entity.ToTable("chat_atendimento");
            });

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.UsuarioId)
                   .HasColumnName("usuario_id");

                entity.Property(e => e.IsOnline)
                   .HasColumnName("is_online");

                entity.Property(e => e.SignalrId)
                   .IsRequired()
                   .HasMaxLength(22)
                  .HasColumnName("Signalr_id");

                entity.Property(e => e.TimeStamp)
                   .HasColumnType("timestamp")
                   .HasColumnName("time_stamp");

                entity.HasOne(e => e.Usuario)
                    .WithMany(e => e.Connections)
                    .HasForeignKey(e => e.UsuarioId);


                entity.ToTable("connection");
            });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString, SqlOptions =>
            {
                SqlOptions.MigrationsHistoryTable("ef_migrations_history", "public");
                SqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(150), null);
            });
        }

    }
}
