using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DAL.Migrations
{
    public partial class AddArticleProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Article",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Article",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Article",
                table: "Products",
                column: "Article",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Article",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Article",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Article",
                table: "Products",
                column: "Article",
                unique: true,
                filter: "[Article] IS NOT NULL");
        }
    }
}
