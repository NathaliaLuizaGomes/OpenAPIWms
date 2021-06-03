using Microsoft.EntityFrameworkCore.Migrations;

namespace WmsSystem.Repository.Migrations
{
    public partial class RemoverCamposCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercDesconto",
                table: "Categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PercDesconto",
                table: "Categoria",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
