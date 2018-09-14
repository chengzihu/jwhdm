using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class Initial05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "UserMemberLessonMind");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserMemberLessonMind");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "UserMemberLessonMind");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "UserMemberLessonMind",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserMemberLessonMind",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "UserMemberLessonMind",
                nullable: true);
        }
    }
}
