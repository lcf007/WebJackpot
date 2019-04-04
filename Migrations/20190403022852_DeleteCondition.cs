using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJackpot.Migrations
{
    public partial class DeleteCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jackpots_TriggerConditions_TriggerConditionID1",
                table: "Jackpots");

            migrationBuilder.DropTable(
                name: "TriggerConditions");

            migrationBuilder.DropIndex(
                name: "IX_Jackpots_TriggerConditionID1",
                table: "Jackpots");

            migrationBuilder.DropColumn(
                name: "TriggerConditionID",
                table: "Jackpots");

            migrationBuilder.DropColumn(
                name: "TriggerConditionID1",
                table: "Jackpots");

            migrationBuilder.AddColumn<decimal>(
                name: "TriggerPoints",
                table: "Jackpots",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TriggerPoints",
                table: "Jackpots");

            migrationBuilder.AddColumn<int>(
                name: "TriggerConditionID",
                table: "Jackpots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TriggerConditionID1",
                table: "Jackpots",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TriggerConditions",
                columns: table => new
                {
                    TriggerConditionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JackpotID = table.Column<int>(nullable: false),
                    TriggerPoints = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerConditions", x => x.TriggerConditionID);
                });

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
    }
}
