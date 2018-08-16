using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class update18081702 : Migration
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
                    CreatorUserId = table.Column<long>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    RelationTenantId = table.Column<int>(nullable: true)
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
                name: "TenantAgencys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CallNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    BusinessLicence = table.Column<string>(nullable: true),
                    CoverImage = table.Column<string>(nullable: true),
                    ServiceBegin = table.Column<DateTime>(nullable: false),
                    ServiceEnd = table.Column<DateTime>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantAgencys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantAgencys_AbpTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEmployees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    IDCard = table.Column<string>(nullable: true),
                    RelationUserId = table.Column<long>(nullable: true),
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
                    CreatorUserId = table.Column<long>(nullable: true),
                    RelationTenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEmployees_AbpTenants_RelationTenantId",
                        column: x => x.RelationTenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(maxLength: 20, nullable: false),
                    Photo = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    IDCard = table.Column<string>(maxLength: 20, nullable: true),
                    RelationUserId = table.Column<long>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Armspan = table.Column<double>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    JoinTime = table.Column<DateTime>(nullable: false),
                    JoinAddress = table.Column<string>(nullable: true),
                    JoinExpiry = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Fee = table.Column<double>(nullable: false),
                    AttendanceLesson = table.Column<double>(nullable: false),
                    TotalLesson = table.Column<double>(nullable: false),
                    AttendanceAddress = table.Column<string>(maxLength: 200, nullable: true),
                    Abstract = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: false),
                    RelationTenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMembers_AbpTenants_RelationTenantId",
                        column: x => x.RelationTenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_TenantAgencys_TenantId",
                table: "TenantAgencys",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmployees_RelationTenantId",
                table: "UserEmployees",
                column: "RelationTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmployees_RelationUserId",
                table: "UserEmployees",
                column: "RelationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMembers_RelationTenantId",
                table: "UserMembers",
                column: "RelationTenantId");

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
                name: "TenantAgencys");

            migrationBuilder.DropTable(
                name: "UserEmployees");

            migrationBuilder.DropTable(
                name: "UserMembers");
        }
    }
}
