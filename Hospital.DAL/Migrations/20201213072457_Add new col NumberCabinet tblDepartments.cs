using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.DAL.Migrations
{
    public partial class AddnewcolNumberCabinettblDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberCabinet",
                table: "tblDepartments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberCabinet",
                table: "tblDepartments");
        }
    }
}
