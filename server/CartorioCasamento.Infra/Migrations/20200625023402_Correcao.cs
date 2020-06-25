using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CartorioCasamento.Infra.Migrations
{
    public partial class Correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CASAMENTO_PEDIDO_CASAMENTO_ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_CASAMENTO_USUARIO_UsuarioPrimeiraTestemunhaId",
                table: "CASAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_CASAMENTO_USUARIO_UsuarioSegundaTestemunhaId",
                table: "CASAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_CASAMENTO_ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_CASAMENTO_UsuarioSegundaTestemunhaId",
                table: "CASAMENTO");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "UsuarioSegundaTestemunhaId",
                table: "CASAMENTO");

            migrationBuilder.RenameColumn(
                name: "UsuarioPrimeiraTestemunhaId",
                table: "CASAMENTO",
                newName: "ID_USUARIO_PRIMEIRA_TESTEMUNHA");

            migrationBuilder.RenameIndex(
                name: "IX_CASAMENTO_UsuarioPrimeiraTestemunhaId",
                table: "CASAMENTO",
                newName: "IX_CASAMENTO_ID_USUARIO_PRIMEIRA_TESTEMUNHA");

            migrationBuilder.AddColumn<string>(
                name: "NOM_CIDADE",
                table: "USUARIO",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DAT_PEDIDO_ACEITO",
                table: "PEDIDO_CASAMENTO",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_PEDIDO_CASAMENTO",
                table: "CASAMENTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CASAMENTO_ID_PEDIDO_CASAMENTO",
                table: "CASAMENTO",
                column: "ID_PEDIDO_CASAMENTO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CASAMENTO_ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO",
                column: "ID_USUARIO_SEGUNDA_TESTEMUNHA");

            migrationBuilder.AddForeignKey(
                name: "FK_CASAMENTO_PEDIDO_CASAMENTO_ID_PEDIDO_CASAMENTO",
                table: "CASAMENTO",
                column: "ID_PEDIDO_CASAMENTO",
                principalTable: "PEDIDO_CASAMENTO",
                principalColumn: "ID_PEDIDO_CASAMENTO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CASAMENTO_USUARIO_ID_USUARIO_PRIMEIRA_TESTEMUNHA",
                table: "CASAMENTO",
                column: "ID_USUARIO_PRIMEIRA_TESTEMUNHA",
                principalTable: "USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CASAMENTO_USUARIO_ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO",
                column: "ID_USUARIO_SEGUNDA_TESTEMUNHA",
                principalTable: "USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CASAMENTO_PEDIDO_CASAMENTO_ID_PEDIDO_CASAMENTO",
                table: "CASAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_CASAMENTO_USUARIO_ID_USUARIO_PRIMEIRA_TESTEMUNHA",
                table: "CASAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_CASAMENTO_USUARIO_ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_CASAMENTO_ID_PEDIDO_CASAMENTO",
                table: "CASAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_CASAMENTO_ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO");

            migrationBuilder.DropColumn(
                name: "NOM_CIDADE",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "DAT_PEDIDO_ACEITO",
                table: "PEDIDO_CASAMENTO");

            migrationBuilder.DropColumn(
                name: "ID_PEDIDO_CASAMENTO",
                table: "CASAMENTO");

            migrationBuilder.RenameColumn(
                name: "ID_USUARIO_PRIMEIRA_TESTEMUNHA",
                table: "CASAMENTO",
                newName: "UsuarioPrimeiraTestemunhaId");

            migrationBuilder.RenameIndex(
                name: "IX_CASAMENTO_ID_USUARIO_PRIMEIRA_TESTEMUNHA",
                table: "CASAMENTO",
                newName: "IX_CASAMENTO_UsuarioPrimeiraTestemunhaId");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioSegundaTestemunhaId",
                table: "CASAMENTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CASAMENTO_ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO",
                column: "ID_USUARIO_SEGUNDA_TESTEMUNHA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CASAMENTO_UsuarioSegundaTestemunhaId",
                table: "CASAMENTO",
                column: "UsuarioSegundaTestemunhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CASAMENTO_PEDIDO_CASAMENTO_ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO",
                column: "ID_USUARIO_SEGUNDA_TESTEMUNHA",
                principalTable: "PEDIDO_CASAMENTO",
                principalColumn: "ID_PEDIDO_CASAMENTO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CASAMENTO_USUARIO_UsuarioPrimeiraTestemunhaId",
                table: "CASAMENTO",
                column: "UsuarioPrimeiraTestemunhaId",
                principalTable: "USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CASAMENTO_USUARIO_UsuarioSegundaTestemunhaId",
                table: "CASAMENTO",
                column: "UsuarioSegundaTestemunhaId",
                principalTable: "USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
