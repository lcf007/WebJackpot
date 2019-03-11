using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJackpot.Migrations
{
    public partial class AddTrigger4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TriggeredJackpot_Jackpot_JackpotID",
                table: "TriggeredJackpot");

            migrationBuilder.DropForeignKey(
                name: "FK_TriggeredJackpot_Player_PlayerID",
                table: "TriggeredJackpot");

            migrationBuilder.DropIndex(
                name: "IX_TriggeredJackpot_JackpotID",
                table: "TriggeredJackpot");

            migrationBuilder.DropIndex(
                name: "IX_TriggeredJackpot_PlayerID",
                table: "TriggeredJackpot");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TriggeredJackpot_JackpotID",
                table: "TriggeredJackpot",
                column: "JackpotID");

            migrationBuilder.CreateIndex(
                name: "IX_TriggeredJackpot_PlayerID",
                table: "TriggeredJackpot",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_TriggeredJackpot_Jackpot_JackpotID",
                table: "TriggeredJackpot",
                column: "JackpotID",
                principalTable: "Jackpot",
                principalColumn: "JackpotID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TriggeredJackpot_Player_PlayerID",
                table: "TriggeredJackpot",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
