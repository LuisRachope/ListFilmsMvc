using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListFilmsMvc.Migrations
{
    public partial class Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "TypeCategoryId",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_TypeCategoryId",
                table: "Movie",
                column: "TypeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Category_TypeCategoryId",
                table: "Movie",
                column: "TypeCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Category_TypeCategoryId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Movie_TypeCategoryId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "TypeCategoryId",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Movie",
                nullable: false,
                defaultValue: 0);
        }
    }
}
