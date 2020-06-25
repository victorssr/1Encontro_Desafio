using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CartorioCasamento.Infra.Migrations
{
    public partial class Correcao_TblCasamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "VLR_CASAMENTO",
                table: "CASAMENTO",
                type: "DECIMAL(9, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(9, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID_USUARIO_PRIMEIRA_TESTEMUNHA",
                table: "CASAMENTO",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DAT_ENTRADA",
                table: "CASAMENTO",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DAT_DIARIO_OFICIAL",
                table: "CASAMENTO",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "VLR_CASAMENTO",
                table: "CASAMENTO",
                type: "DECIMAL(9, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(9, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_USUARIO_SEGUNDA_TESTEMUNHA",
                table: "CASAMENTO",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_USUARIO_PRIMEIRA_TESTEMUNHA",
                table: "CASAMENTO",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DAT_ENTRADA",
                table: "CASAMENTO",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DAT_DIARIO_OFICIAL",
                table: "CASAMENTO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
