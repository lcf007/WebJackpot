using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJackpot.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jackpot",
                columns: table => new
                {
                    JackpotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    CurrentWin = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CurrentTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jackpot", x => x.JackpotID);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "TriggeredJackpot",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JackpotID = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    CurrentWin = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TriggerTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggeredJackpot", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TriggeredJackpot_Jackpot_JackpotID",
                        column: x => x.JackpotID,
                        principalTable: "Jackpot",
                        principalColumn: "JackpotID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TriggeredJackpot_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TriggeredJackpot_JackpotID",
                table: "TriggeredJackpot",
                column: "JackpotID");

            migrationBuilder.CreateIndex(
                name: "IX_TriggeredJackpot_PlayerID",
                table: "TriggeredJackpot",
                column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TriggeredJackpot");

            migrationBuilder.DropTable(
                name: "Jackpot");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
