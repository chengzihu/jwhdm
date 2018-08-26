using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class Initial02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonMind_UserMembers_UserMemberId",
                table: "LessonMind");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMembers_LessonMind_LessonMindId",
                table: "UserMembers");

            migrationBuilder.DropIndex(
                name: "IX_UserMembers_LessonMindId",
                table: "UserMembers");

            migrationBuilder.DropIndex(
                name: "IX_LessonMind_UserMemberId",
                table: "LessonMind");

            migrationBuilder.DropColumn(
                name: "LessonMindId",
                table: "UserMembers");

            migrationBuilder.DropColumn(
                name: "UserMemberId",
                table: "LessonMind");

            migrationBuilder.CreateTable(
                name: "UserMemberLessonMind",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    UserMemberId = table.Column<long>(nullable: false),
                    LessonMindId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMemberLessonMind", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMemberLessonMind_LessonMind_LessonMindId",
                        column: x => x.LessonMindId,
                        principalTable: "LessonMind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMemberLessonMind_UserMembers_UserMemberId",
                        column: x => x.UserMemberId,
                        principalTable: "UserMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMemberLessonMind_LessonMindId",
                table: "UserMemberLessonMind",
                column: "LessonMindId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMemberLessonMind_UserMemberId",
                table: "UserMemberLessonMind",
                column: "UserMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMemberLessonMind");

            migrationBuilder.AddColumn<int>(
                name: "LessonMindId",
                table: "UserMembers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserMemberId",
                table: "LessonMind",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMembers_LessonMindId",
                table: "UserMembers",
                column: "LessonMindId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonMind_UserMemberId",
                table: "LessonMind",
                column: "UserMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonMind_UserMembers_UserMemberId",
                table: "LessonMind",
                column: "UserMemberId",
                principalTable: "UserMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMembers_LessonMind_LessonMindId",
                table: "UserMembers",
                column: "LessonMindId",
                principalTable: "LessonMind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
