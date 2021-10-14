using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_CidadesClientes.Migrations
{
    public partial class TiraEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_EstadoId",
                table: "Cidades");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Cidades");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Cidades",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Cidades");

            migrationBuilder.AddColumn<Guid>(
                name: "EstadoId",
                table: "Cidades",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_EstadoId",
                table: "Cidades",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
