using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class Initial07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberLessonMind_LessonMind_LessonMindId",
                table: "UserMemberLessonMind");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberLessonMind_UserMembers_UserMemberId",
                table: "UserMemberLessonMind");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMemberLessonMind",
                table: "UserMemberLessonMind");

            migrationBuilder.RenameTable(
                name: "UserMemberLessonMind",
                newName: "UserMemberLessonMinds");

            migrationBuilder.RenameIndex(
                name: "IX_UserMemberLessonMind_UserMemberId",
                table: "UserMemberLessonMinds",
                newName: "IX_UserMemberLessonMinds_UserMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMemberLessonMind_LessonMindId",
                table: "UserMemberLessonMinds",
                newName: "IX_UserMemberLessonMinds_LessonMindId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMemberLessonMinds",
                table: "UserMemberLessonMinds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberLessonMinds_LessonMind_LessonMindId",
                table: "UserMemberLessonMinds",
                column: "LessonMindId",
                principalTable: "LessonMind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberLessonMinds_UserMembers_UserMemberId",
                table: "UserMemberLessonMinds",
                column: "UserMemberId",
                principalTable: "UserMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberLessonMinds_LessonMind_LessonMindId",
                table: "UserMemberLessonMinds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberLessonMinds_UserMembers_UserMemberId",
                table: "UserMemberLessonMinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMemberLessonMinds",
                table: "UserMemberLessonMinds");

            migrationBuilder.RenameTable(
                name: "UserMemberLessonMinds",
                newName: "UserMemberLessonMind");

            migrationBuilder.RenameIndex(
                name: "IX_UserMemberLessonMinds_UserMemberId",
                table: "UserMemberLessonMind",
                newName: "IX_UserMemberLessonMind_UserMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMemberLessonMinds_LessonMindId",
                table: "UserMemberLessonMind",
                newName: "IX_UserMemberLessonMind_LessonMindId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMemberLessonMind",
                table: "UserMemberLessonMind",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberLessonMind_LessonMind_LessonMindId",
                table: "UserMemberLessonMind",
                column: "LessonMindId",
                principalTable: "LessonMind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberLessonMind_UserMembers_UserMemberId",
                table: "UserMemberLessonMind",
                column: "UserMemberId",
                principalTable: "UserMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
