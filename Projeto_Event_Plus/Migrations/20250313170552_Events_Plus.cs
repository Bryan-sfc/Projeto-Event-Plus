using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Event_Plus.Migrations
{
    /// <inheritdoc />
    public partial class Events_Plus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    InstituicaoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeFantasma = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(120)", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.InstituicaoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    TipoEventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoEvento = table.Column<string>(type: "VARCHAR(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.TipoEventoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    TipoUsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoUsuario = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.TipoUsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventosID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Evento = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    TipoEventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituicaoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventosID);
                    table.ForeignKey(
                        name: "FK_Eventos_Instituicao_InstituicaoID",
                        column: x => x.InstituicaoID,
                        principalTable: "Instituicao",
                        principalColumn: "InstituicaoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventos_TipoEvento_TipoEventoID",
                        column: x => x.TipoEventoID,
                        principalTable: "TipoEvento",
                        principalColumn: "TipoEventoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    TipoUsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_TipoUsuarioID",
                        column: x => x.TipoUsuarioID,
                        principalTable: "TipoUsuario",
                        principalColumn: "TipoUsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ComentarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Exibe = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioID);
                    table.ForeignKey(
                        name: "FK_Comentario_Eventos_EventoID",
                        column: x => x.EventoID,
                        principalTable: "Eventos",
                        principalColumn: "EventosID");
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    PresencaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situcao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.PresencaID);
                    table.ForeignKey(
                        name: "FK_Presenca_Eventos_EventoID",
                        column: x => x.EventoID,
                        principalTable: "Eventos",
                        principalColumn: "EventosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presenca_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_EventoID",
                table: "Comentario",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioID",
                table: "Comentario",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_InstituicaoID",
                table: "Eventos",
                column: "InstituicaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventoID",
                table: "Eventos",
                column: "TipoEventoID");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_CNPJ",
                table: "Instituicao",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_EventoID",
                table: "Presenca",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_UsuarioID",
                table: "Presenca",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioID",
                table: "Usuario",
                column: "TipoUsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
