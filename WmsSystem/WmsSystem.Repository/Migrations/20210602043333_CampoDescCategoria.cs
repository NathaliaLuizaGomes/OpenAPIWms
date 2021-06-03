using Microsoft.EntityFrameworkCore.Migrations;

namespace WmsSystem.Repository.Migrations
{
    public partial class CampoDescCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
            name: "PercDesconto",
            table: "Categoria",
            type: "real",
            nullable: false,
            defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercDesconto",
                table: "Categoria");
        }
    }
}
