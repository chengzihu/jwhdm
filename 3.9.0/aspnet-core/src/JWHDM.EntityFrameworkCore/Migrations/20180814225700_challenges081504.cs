using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class challenges081504 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phote",
                table: "UserMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phote",
                table: "UserEmployees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phote",
                table: "UserMembers");

            migrationBuilder.DropColumn(
                name: "Phote",
                table: "UserEmployees");
        }
    }
}
