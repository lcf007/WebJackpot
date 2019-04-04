using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJackpot.Migrations
{
    public partial class ChangeVaribleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TriggeredJackpot_Jackpot_JackpotID",
                table: "TriggeredJackpot");

            migrationBuilder.DropForeignKey(
                name: "FK_TriggeredJackpot_Player_PlayerID",
                table: "TriggeredJackpot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TriggeredJackpot",
                table: "TriggeredJackpot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TriggerCondition",
                table: "TriggerCondition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jackpot",
                table: "Jackpot");

            migrationBuilder.RenameTable(
                name: "TriggeredJackpot",
                newName: "TriggeredJackpots");

            migrationBuilder.RenameTable(
                name: "TriggerCondition",
                newName: "TriggerConditions");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "Jackpot",
                newName: "Jackpots");

            migrationBuilder.RenameIndex(
                name: "IX_TriggeredJackpot_PlayerID",
                table: "TriggeredJackpots",
                newName: "IX_TriggeredJackpots_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_TriggeredJackpot_JackpotID",
                table: "TriggeredJackpots",
                newName: "IX_TriggeredJackpots_JackpotID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TriggeredJackpots",
                table: "TriggeredJackpots",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TriggerConditions",
                table: "TriggerConditions",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "PlayerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jackpots",
                table: "Jackpots",
                column: "JackpotID");

            migrationBuilder.AddForeignKey(
                name: "FK_TriggeredJackpots_Jackpots_JackpotID",
                table: "TriggeredJackpots",
                column: "JackpotID",
                principalTable: "Jackpots",
                principalColumn: "JackpotID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TriggeredJackpots_Players_PlayerID",
                table: "TriggeredJackpots",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TriggeredJackpots_Jackpots_JackpotID",
                table: "TriggeredJackpots");

            migrationBuilder.DropForeignKey(
                name: "FK_TriggeredJackpots_Players_PlayerID",
                table: "TriggeredJackpots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TriggeredJackpots",
                table: "TriggeredJackpots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TriggerConditions",
                table: "TriggerConditions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jackpots",
                table: "Jackpots");

            migrationBuilder.RenameTable(
                name: "TriggeredJackpots",
                newName: "TriggeredJackpot");

            migrationBuilder.RenameTable(
                name: "TriggerConditions",
                newName: "TriggerCondition");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "Jackpots",
                newName: "Jackpot");

            migrationBuilder.RenameIndex(
                name: "IX_TriggeredJackpots_PlayerID",
                table: "TriggeredJackpot",
                newName: "IX_TriggeredJackpot_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_TriggeredJackpots_JackpotID",
                table: "TriggeredJackpot",
                newName: "IX_TriggeredJackpot_JackpotID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TriggeredJackpot",
                table: "TriggeredJackpot",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TriggerCondition",
                table: "TriggerCondition",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "PlayerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jackpot",
                table: "Jackpot",
                column: "JackpotID");

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
