using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsMVC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id    = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    Mark  = table.Column<int>(nullable: true),
                    Name  = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
