using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WmsSystem.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PCusto = table.Column<float>(type: "real", nullable: false),
                    PVenda = table.Column<float>(type: "real", nullable: false),
                    Quantidade = table.Column<float>(type: "real", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    UndMedida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
