using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class challenges0815 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChallengerId = table.Column<long>(nullable: false),
                    ToChallengerId = table.Column<long>(nullable: false),
                    ChallengeDeclaration = table.Column<string>(nullable: true),
                    ToChallengeDeclaration = table.Column<string>(nullable: true),
                    ChallengeTime = table.Column<DateTime>(nullable: true),
                    ConfirmUserId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_AbpUsers_ChallengerId",
                        column: x => x.ChallengerId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challenges_AbpUsers_ConfirmUserId",
                        column: x => x.ConfirmUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challenges_AbpUsers_ToChallengerId",
                        column: x => x.ToChallengerId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IDCard = table.Column<string>(nullable: true),
                    RelationUserId = table.Column<long>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Armspan = table.Column<double>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    JoinTime = table.Column<DateTime>(nullable: false),
                    JoinAddress = table.Column<string>(nullable: true),
                    JoinExpiry = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Abstract = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEmployees_AbpUsers_RelationUserId",
                        column: x => x.RelationUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IDCard = table.Column<string>(nullable: true),
                    RelationUserId = table.Column<long>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Armspan = table.Column<double>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    JoinTime = table.Column<DateTime>(nullable: false),
                    JoinAddress = table.Column<string>(nullable: true),
                    JoinExpiry = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Fee = table.Column<double>(nullable: false),
                    AttendanceLesson = table.Column<double>(nullable: false),
                    TotalLesson = table.Column<double>(nullable: false),
                    AttendanceAddress = table.Column<double>(nullable: false),
                    Abstract = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMembers_AbpUsers_RelationUserId",
                        column: x => x.RelationUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ChallengerId",
                table: "Challenges",
                column: "ChallengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ConfirmUserId",
                table: "Challenges",
                column: "ConfirmUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ToChallengerId",
                table: "Challenges",
                column: "ToChallengerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmployees_RelationUserId",
                table: "UserEmployees",
                column: "RelationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMembers_RelationUserId",
                table: "UserMembers",
                column: "RelationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "UserEmployees");

            migrationBuilder.DropTable(
                name: "UserMembers");
        }
    }
}
