using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberLessonMinds_LessonMind_LessonMindId",
                table: "UserMemberLessonMinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonMind",
                table: "LessonMind");

            migrationBuilder.RenameTable(
                name: "LessonMind",
                newName: "LessonMinds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonMinds",
                table: "LessonMinds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberLessonMinds_LessonMinds_LessonMindId",
                table: "UserMemberLessonMinds",
                column: "LessonMindId",
                principalTable: "LessonMinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberLessonMinds_LessonMinds_LessonMindId",
                table: "UserMemberLessonMinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonMinds",
                table: "LessonMinds");

            migrationBuilder.RenameTable(
                name: "LessonMinds",
                newName: "LessonMind");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonMind",
                table: "LessonMind",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberLessonMinds_LessonMind_LessonMindId",
                table: "UserMemberLessonMinds",
                column: "LessonMindId",
                principalTable: "LessonMind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
