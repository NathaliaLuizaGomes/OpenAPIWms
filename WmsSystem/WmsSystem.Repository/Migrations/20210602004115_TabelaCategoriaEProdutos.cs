using Microsoft.EntityFrameworkCore.Migrations;

namespace WmsSystem.Repository.Migrations
{
    public partial class TabelaCategoriaEProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriasIdCategoria",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Desativado",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriasIdCategoria",
                table: "Produtos",
                column: "CategoriasIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categoria_CategoriasIdCategoria",
                table: "Produtos",
                column: "CategoriasIdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categoria_CategoriasIdCategoria",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CategoriasIdCategoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CategoriasIdCategoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Desativado",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Produtos");
        }
    }
}
