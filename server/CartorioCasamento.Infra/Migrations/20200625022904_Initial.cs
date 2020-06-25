using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CartorioCasamento.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADO",
                columns: table => new
                {
                    ID_ESTADO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SGL_ESTADO = table.Column<string>(maxLength: 2, nullable: false),
                    NOM_ESTADO = table.Column<string>(maxLength: 100, nullable: false),
                    VLR_CASAMENTO = table.Column<decimal>(type: "DECIMAL(9, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADO", x => x.ID_ESTADO);
                });

            migrationBuilder.CreateTable(
                name: "REGIME_BENS",
                columns: table => new
                {
                    ID_REGIME_BENS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DSC_REGIME_BENS = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGIME_BENS", x => x.ID_REGIME_BENS);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    END_EMAIL = table.Column<string>(maxLength: 300, nullable: false),
                    NUM_CELULAR = table.Column<string>(maxLength: 14, nullable: false),
                    DSC_SENHA = table.Column<string>(maxLength: 500, nullable: false),
                    NOM_USUARIO = table.Column<string>(maxLength: 500, nullable: false),
                    DAT_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    NUM_CPF = table.Column<string>(maxLength: 14, nullable: false),
                    NUM_RG = table.Column<string>(maxLength: 50, nullable: false),
                    IND_DESIMPEDIDO = table.Column<bool>(nullable: false),
                    DSC_LOGRADOURO = table.Column<string>(maxLength: 200, nullable: false),
                    NUM_ENDERECO = table.Column<string>(maxLength: 10, nullable: false),
                    DSC_COMPLEMENTO = table.Column<string>(maxLength: 10, nullable: true),
                    NOM_BAIRRO = table.Column<string>(maxLength: 200, nullable: false),
                    COD_CEP = table.Column<string>(maxLength: 10, nullable: false),
                    ID_ESTADO = table.Column<int>(nullable: false),
                    Cep = table.Column<string>(nullable: true),
                    NOM_ARQUIVO_FOTO = table.Column<string>(maxLength: 100, nullable: false),
                    NOM_ARQUIVO_CERTIDAO_NASCIMENTO = table.Column<string>(maxLength: 100, nullable: false),
                    NOM_ARQUIVO_RG = table.Column<string>(maxLength: 100, nullable: false),
                    NOM_ARQUIVO_CPF = table.Column<string>(maxLength: 100, nullable: false),
                    NOM_ARQUIVO_CERTIDAO_DIVORCIO = table.Column<string>(maxLength: 100, nullable: false),
                    NOM_ARQUIVO_SENTENCA_DIVORCIO = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "FK_USUARIO_ESTADO_ID_ESTADO",
                        column: x => x.ID_ESTADO,
                        principalTable: "ESTADO",
                        principalColumn: "ID_ESTADO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDO_CASAMENTO",
                columns: table => new
                {
                    ID_PEDIDO_CASAMENTO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USUARIO_SOLICITANTE = table.Column<int>(nullable: false),
                    ID_USUARIO_SOLICITADO = table.Column<int>(nullable: false),
                    ID_REGIME_BENS = table.Column<int>(nullable: false),
                    DAT_PEDIDO_NEGADO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO_CASAMENTO", x => x.ID_PEDIDO_CASAMENTO);
                    table.ForeignKey(
                        name: "FK_PEDIDO_CASAMENTO_REGIME_BENS_ID_REGIME_BENS",
                        column: x => x.ID_REGIME_BENS,
                        principalTable: "REGIME_BENS",
                        principalColumn: "ID_REGIME_BENS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PEDIDO_CASAMENTO_USUARIO_ID_USUARIO_SOLICITADO",
                        column: x => x.ID_USUARIO_SOLICITADO,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PEDIDO_CASAMENTO_USUARIO_ID_USUARIO_SOLICITANTE",
                        column: x => x.ID_USUARIO_SOLICITANTE,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CASAMENTO",
                columns: table => new
                {
                    ID_CASAMENTO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_REFERENCIA = table.Column<Guid>(nullable: false),
                    ID_USUARIO_SEGUNDA_TESTEMUNHA = table.Column<int>(nullable: false),
                    UsuarioPrimeiraTestemunhaId = table.Column<int>(nullable: false),
                    UsuarioSegundaTestemunhaId = table.Column<int>(nullable: false),
                    DAT_ENTRADA = table.Column<DateTime>(nullable: false),
                    VLR_CASAMENTO = table.Column<decimal>(type: "DECIMAL(9, 2)", nullable: false),
                    DAT_APROVACAO_ENTRADA = table.Column<DateTime>(nullable: true),
                    DAT_CASAMENTO = table.Column<DateTime>(nullable: true),
                    DAT_REALIZACAO_CASAMENTO = table.Column<DateTime>(nullable: true),
                    DSC_LINK_CERIMONIA = table.Column<string>(maxLength: 100, nullable: true),
                    DAT_DIARIO_OFICIAL = table.Column<string>(nullable: true),
                    NOM_ARQUIVO_FOTO = table.Column<string>(maxLength: 100, nullable: true),
                    DAT_DIVORCIO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASAMENTO", x => x.ID_CASAMENTO);
                    table.ForeignKey(
                        name: "FK_CASAMENTO_PEDIDO_CASAMENTO_ID_USUARIO_SEGUNDA_TESTEMUNHA",
                        column: x => x.ID_USUARIO_SEGUNDA_TESTEMUNHA,
                        principalTable: "PEDIDO_CASAMENTO",
                        principalColumn: "ID_PEDIDO_CASAMENTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CASAMENTO_USUARIO_UsuarioPrimeiraTestemunhaId",
                        column: x => x.UsuarioPrimeiraTestemunhaId,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CASAMENTO_USUARIO_UsuarioSegundaTestemunhaId",
                        column: x => x.UsuarioSegundaTestemunhaId,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CASAMENTO_ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO",
                column: "ID_USUARIO_SEGUNDA_TESTEMUNHA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CASAMENTO_UsuarioPrimeiraTestemunhaId",
                table: "CASAMENTO",
                column: "UsuarioPrimeiraTestemunhaId");

            migrationBuilder.CreateIndex(
                name: "IX_CASAMENTO_UsuarioSegundaTestemunhaId",
                table: "CASAMENTO",
                column: "UsuarioSegundaTestemunhaId");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_CASAMENTO_ID_REGIME_BENS",
                table: "PEDIDO_CASAMENTO",
                column: "ID_REGIME_BENS");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_CASAMENTO_ID_USUARIO_SOLICITADO",
                table: "PEDIDO_CASAMENTO",
                column: "ID_USUARIO_SOLICITADO");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_CASAMENTO_ID_USUARIO_SOLICITANTE",
                table: "PEDIDO_CASAMENTO",
                column: "ID_USUARIO_SOLICITANTE");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ID_ESTADO",
                table: "USUARIO",
                column: "ID_ESTADO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CASAMENTO");

            migrationBuilder.DropTable(
                name: "PEDIDO_CASAMENTO");

            migrationBuilder.DropTable(
                name: "REGIME_BENS");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "ESTADO");
        }
    }
}
