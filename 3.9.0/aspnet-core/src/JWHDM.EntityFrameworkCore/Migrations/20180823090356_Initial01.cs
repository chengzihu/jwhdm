using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class Initial01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantAgencys_AbpTenants_TenantId",
                table: "TenantAgencys");

            migrationBuilder.DropIndex(
                name: "IX_TenantAgencys_TenantId",
                table: "TenantAgencys");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "UserMembers",
                newName: "LessonMindId");

            migrationBuilder.CreateTable(
                name: "LessonMind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MindName = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserMemberId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonMind", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonMind_UserMembers_UserMemberId",
                        column: x => x.UserMemberId,
                        principalTable: "UserMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMembers_LessonMindId",
                table: "UserMembers",
                column: "LessonMindId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonMind_UserMemberId",
                table: "LessonMind",
                column: "UserMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMembers_LessonMind_LessonMindId",
                table: "UserMembers",
                column: "LessonMindId",
                principalTable: "LessonMind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMembers_LessonMind_LessonMindId",
                table: "UserMembers");

            migrationBuilder.DropTable(
                name: "LessonMind");

            migrationBuilder.DropIndex(
                name: "IX_UserMembers_LessonMindId",
                table: "UserMembers");

            migrationBuilder.RenameColumn(
                name: "LessonMindId",
                table: "UserMembers",
                newName: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_TenantAgencys_TenantId",
                table: "TenantAgencys",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantAgencys_AbpTenants_TenantId",
                table: "TenantAgencys",
                column: "TenantId",
                principalTable: "AbpTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
