using Microsoft.EntityFrameworkCore.Migrations;

namespace WmsSystem.Repository.Migrations
{
    public partial class Acrescimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Acrestimo",
                table: "Categoria",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acrestimo",
                table: "Categoria");
        }
    }
}
