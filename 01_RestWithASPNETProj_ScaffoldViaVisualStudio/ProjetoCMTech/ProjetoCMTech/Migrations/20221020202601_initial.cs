using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoCMTech.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.id);

            });

            migrationBuilder.CreateTable(
                name: "grupo",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo", x => x.id);

                });

            migrationBuilder.CreateTable(
                name: "segmento",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_segmento", x => x.id);

                });

            migrationBuilder.CreateTable(
                name: "organizacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false),
                    segmento_id = table.Column<int>(type: "INTEGER", nullable: false),
                    grupo_id = table.Column<int>(type: "INTEGER", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    telefone = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_organizacao_segmento_segmento_id",
                        column: x => x.segmento_id,
                        principalTable: "segmento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_organizacao_grupo_grupo_id",
                        column: x => x.grupo_id,
                        principalTable: "grupo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_organizacao_grupo_id",
                table: "organizacao",
                column: "grupo_id");

            migrationBuilder.CreateIndex(
                name: "IX_organizacao_segmento_id",
                table: "organizacao",
                column: "segmento_id");

            migrationBuilder.CreateTable(
                name: "status_atendimento",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status_atendimento", x => x.id);

                });

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false),
                    organizacao_id = table.Column<int>(type: "INTEGER", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_departamento_organizacao_organizacao_id",
                        column: x => x.organizacao_id,
                        principalTable: "organizacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departamento_organizacao_id",
                table: "departamento",
                column: "organizacao_id");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false),
                    departamento_id = table.Column<int>(type: "INTEGER", nullable: true),
                    organizacao_id = table.Column<int>(type: "INTEGER", nullable: true),
                    perfil_id = table.Column<int>(type: "INTEGER", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    senha = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_departamento_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "departamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_organizacao_organizacao_id",
                        column: x => x.organizacao_id,
                        principalTable: "organizacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                       name: "FK_usuario_perfil_perfil_id",
                       column: x => x.perfil_id,
                       principalTable: "perfil",
                       principalColumn: "id",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_departamento_id",
                table: "usuario",
                column: "departamento_id");
       
            migrationBuilder.CreateIndex(
               
                name: "IX_usuario_organizacao_id",
                table: "usuario",
                column: "organizacao_id");
        
            migrationBuilder.CreateIndex(
               
                name: "IX_usuario_perfil_id",
                table: "usuario",
                column: "perfil_id");

            migrationBuilder.CreateTable(
                name: "atendimento",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false),
                    status_atendimento_id = table.Column<int>(type: "SERIAL", nullable: false),
                    departamento_id = table.Column<int>(type: "SERIAL", nullable: false),
                    usuario_id = table.Column<int>(type: "SERIAL", nullable: false),
                    cliente_id = table.Column<int>(type: "SERIAL", nullable: false),
                    organizacao_id = table.Column<int>(type: "SERIAL", nullable: false),
                    data_hora_atendimento = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atendimento", x => x.id);
                    table.ForeignKey(
                        name: "FK_atendimento_status_atendimento_status_atendimento_id",
                        column: x => x.status_atendimento_id,
                        principalTable: "status_atendimento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atendimento_departamento_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "departamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atendimento_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atendimento_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atendimento_organizacao_organizacao_id",
                        column: x => x.organizacao_id,
                        principalTable: "organizacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_atendimento_status_atendimento_id",
                table: "atendimento",
                column: "status_atendimento_id");

            migrationBuilder.CreateIndex(
                name: "IX_atendimento_departamento_id",
                table: "atendimento",
                column: "departamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_atendimento_usuario_id",
                table: "atendimento",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_atendimento_cliente_id",
                table: "atendimento",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_atendimento_organizacao_id",
                table: "atendimento",
                column: "organizacao_id");

            migrationBuilder.CreateTable(
                name: "chat_atendimento",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false),
                    atendimento_id = table.Column<int>(type: "INTEGER", nullable: false),
                    remetente_id = table.Column<int>(type: "INTEGER", nullable: true),
                    destinatario_id = table.Column<int>(type: "INTEGER", nullable: true),
                    data_hora = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    messagem = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_atendimento", x => x.id);
                    table.ForeignKey(
                        name: "FK_chat_atendimento_atendimento_atendimento_id",
                        column: x => x.atendimento_id,
                        principalTable: "atendimento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chat_atendimento_usuario_remetente",
                        column: x => x.remetente_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                       name: "FK_chat_atendimento_usuario_destinatario",
                       column: x => x.destinatario_id,
                       principalTable: "usuario",
                       principalColumn: "id",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chat_atendimento_atendimento_id",
                table: "chat_atendimento",
                column: "atendimento_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_atendimento_remetente",
                table: "chat_atendimento",
                column: "remetente_id");

            migrationBuilder.CreateIndex(
               name: "IX_chat_atendimento_destinatario",
               table: "chat_atendimento",
               column: "destinatario_id");

            migrationBuilder.CreateTable(
                name: "connection",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false),
                    usuario_id = table.Column<int>(type: "SERIAL", nullable: false),
                    is_online = table.Column<bool>(type: "SERIAL", nullable: false),
                    Signalr_id = table.Column<string>(type: "VARCHAR(255)", maxLength: 22, nullable: false),
                    time_stamp = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.id);
                    table.ForeignKey(
                        name: "FK_Connection_Usuario_UsuarioId",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
            table: "segmento",
            columns: new[] { "id", "nome" },
            columnTypes: new[] { "SERIAL", "VARCHAR(255)" },
            values: new object[,]
            {
            { 1, "Comercio"},
            { 2, "Tecnologia"},
            { 3, "Varejo"}

            });

            migrationBuilder.InsertData(
               table: "grupo",
               columnTypes: new[] { "SERIAL", "VARCHAR(255)" },
               columns: new[] { "id", "nome" },
               values: new object[,]
               {
                { 1, "CMTECH"}

               }
            );

            migrationBuilder.InsertData(
               table: "status_atendimento",
               columns: new[] { "id", "nome" },
               columnTypes: new[] { "SERIAL", "VARCHAR(255)" },
               values: new object[,]
               {
         { 1, "Novo"},
         { 2, "Em atendimento"},
         { 3, "Encerrado"}

               }
           );

            migrationBuilder.InsertData(
               table: "perfil",
               columns: new[] { "id", "nome" },
               columnTypes: new[] { "SERIAL", "VARCHAR(255)" },
               values: new object[,]
               {
                { 1, "Administrador"},
                { 2, "Tecnico"},
                { 3, "Cliente"}

               }
           );

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "nome", "perfil_id", "email", "senha", "data_cadastro" },
                columnTypes: new[] { "SERIAL", "VARCHAR(255)", "INTEGER", "VARCHAR(255)", "VARCHAR(255)", "datetime" },
                values: new object[,]
                {
                { 1, "Administrador", 1 ,"suporte@cmtech.com.br","f1acec1995466c79bf1aa013918eca8b","2022-09-20 00:00:00" }

                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfil");
            migrationBuilder.DropTable(
                name: "grupo");
            migrationBuilder.DropTable(
                name: "segmento");
            migrationBuilder.DropTable(
               name: "organizacao");
            migrationBuilder.DropTable(
               name: "status_atendimento");
            migrationBuilder.DropTable(
               name: "departamento");
            migrationBuilder.DropTable(
               name: "usuario");
            migrationBuilder.DropTable(
              name: "atendimento");
            migrationBuilder.DropTable(
              name: "chat_atendimento");
            migrationBuilder.DropTable(
              name: "connection");
        }
    }
}
