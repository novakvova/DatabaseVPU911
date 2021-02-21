using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogForm.Migrations
{
    public partial class AddtblBreedsaddcolUrlSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlSlug",
                table: "tblBreeds",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlSlug",
                table: "tblBreeds");
        }
    }
}
