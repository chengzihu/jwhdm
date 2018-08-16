using Microsoft.EntityFrameworkCore.Migrations;

namespace JWHDM.Migrations
{
    public partial class update18081703 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Challenges_RelationTenantId",
                table: "Challenges",
                column: "RelationTenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_AbpTenants_RelationTenantId",
                table: "Challenges",
                column: "RelationTenantId",
                principalTable: "AbpTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_AbpTenants_RelationTenantId",
                table: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_RelationTenantId",
                table: "Challenges");
        }
    }
}
