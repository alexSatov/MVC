using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsMVC.Migrations
{
    public partial class Phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name        : "Mark",
                table       : "Student",
                nullable    : true,
                defaultValue: 0,
                oldClrType  : typeof(int),
                oldNullable : true);

            migrationBuilder.AddColumn<string>(
                name     : "Phone",
                table    : "Student",
                maxLength: 12,
                nullable : true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name : "Phone",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name           : "Mark",
                table          : "Student",
                nullable       : true,
                oldClrType     : typeof(int),
                oldNullable    : true,
                oldDefaultValue: 0);
        }
    }
}
