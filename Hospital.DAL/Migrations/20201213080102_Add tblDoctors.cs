using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.DAL.Migrations
{
    public partial class AddtblDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    Stage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblDoctors_tblDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "tblDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctors_DepartmentId",
                table: "tblDoctors",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDoctors");
        }
    }
}
