using Microsoft.EntityFrameworkCore.Migrations;

namespace identity_rest_service.Migrations
{
    public partial class UpdateAgentFOREIGNKEY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AgentProfile_AgentProfileID",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_AgentProfileID",
                table: "UserProfile");

            migrationBuilder.AlterColumn<int>(
                name: "AgentProfileID",
                table: "UserProfile",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_AgentProfileID",
                table: "UserProfile",
                column: "AgentProfileID",
                unique: true,
                filter: "[AgentProfileID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AgentProfile_AgentProfileID",
                table: "UserProfile",
                column: "AgentProfileID",
                principalTable: "AgentProfile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AgentProfile_AgentProfileID",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_AgentProfileID",
                table: "UserProfile");

            migrationBuilder.AlterColumn<int>(
                name: "AgentProfileID",
                table: "UserProfile",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_AgentProfileID",
                table: "UserProfile",
                column: "AgentProfileID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AgentProfile_AgentProfileID",
                table: "UserProfile",
                column: "AgentProfileID",
                principalTable: "AgentProfile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
