using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WmsSystem.Repository.Migrations
{
    public partial class TabelaComprasECampoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Seq = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    IdMercadoria = table.Column<int>(type: "int", nullable: false),
                    QtdEntrada = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Seq);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
