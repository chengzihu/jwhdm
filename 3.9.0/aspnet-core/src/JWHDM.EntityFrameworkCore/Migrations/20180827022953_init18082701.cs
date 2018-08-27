using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class init18082701 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMembers_AbpUsers_RelationUserId",
                table: "UserMembers");

            migrationBuilder.DropIndex(
                name: "IX_UserMembers_RelationUserId",
                table: "UserMembers");

            migrationBuilder.DropColumn(
                name: "RelationUserId",
                table: "UserMembers");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserMembers",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserMembers");

            migrationBuilder.AddColumn<long>(
                name: "RelationUserId",
                table: "UserMembers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMembers_RelationUserId",
                table: "UserMembers",
                column: "RelationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMembers_AbpUsers_RelationUserId",
                table: "UserMembers",
                column: "RelationUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
