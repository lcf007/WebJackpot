using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebJackpot.Migrations.ApplicationDb
{
    public partial class CleanDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jackpots",
                columns: table => new
                {
                    JackpotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    CurrentWin = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TriggerPoints = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CurrentTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jackpots", x => x.JackpotID);
                });

            migrationBuilder.CreateTable(
                name: "TriggeredJackpots",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JackpotID = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CurrentWin = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TriggerTime = table.Column<DateTime>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggeredJackpots", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TriggeredJackpots_Jackpots_JackpotID",
                        column: x => x.JackpotID,
                        principalTable: "Jackpots",
                        principalColumn: "JackpotID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TriggeredJackpots_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TriggeredJackpots_JackpotID",
                table: "TriggeredJackpots",
                column: "JackpotID");

            migrationBuilder.CreateIndex(
                name: "IX_TriggeredJackpots_PlayerId",
                table: "TriggeredJackpots",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TriggeredJackpots");

            migrationBuilder.DropTable(
                name: "Jackpots");
        }
    }
}
