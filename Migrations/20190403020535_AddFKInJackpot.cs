using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJackpot.Migrations
{
    public partial class AddFKInJackpot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TriggerConditions",
                newName: "TriggerConditionID");

            migrationBuilder.AddColumn<int>(
                name: "TriggerConditionID",
                table: "Jackpots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TriggerConditionID1",
                table: "Jackpots",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jackpots_TriggerConditionID1",
                table: "Jackpots",
                column: "TriggerConditionID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Jackpots_TriggerConditions_TriggerConditionID1",
                table: "Jackpots",
                column: "TriggerConditionID1",
                principalTable: "TriggerConditions",
                principalColumn: "TriggerConditionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jackpots_TriggerConditions_TriggerConditionID1",
                table: "Jackpots");

            migrationBuilder.DropIndex(
                name: "IX_Jackpots_TriggerConditionID1",
                table: "Jackpots");

            migrationBuilder.DropColumn(
                name: "TriggerConditionID",
                table: "Jackpots");

            migrationBuilder.DropColumn(
                name: "TriggerConditionID1",
                table: "Jackpots");

            migrationBuilder.RenameColumn(
                name: "TriggerConditionID",
                table: "TriggerConditions",
                newName: "ID");
        }
    }
}
