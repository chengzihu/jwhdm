using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class challenges081502 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "UserMembers",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "UserMembers");
        }
    }
}
