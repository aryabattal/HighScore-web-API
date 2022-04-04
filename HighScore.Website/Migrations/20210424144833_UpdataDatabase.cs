using Microsoft.EntityFrameworkCore.Migrations;

namespace HighScore.Website.Migrations
{
    public partial class UpdataDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_HighScores_HighscoreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_HighscoreId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HighscoreId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "HighScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HighScores_GameId",
                table: "HighScores",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_HighScores_Games_GameId",
                table: "HighScores",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HighScores_Games_GameId",
                table: "HighScores");

            migrationBuilder.DropIndex(
                name: "IX_HighScores_GameId",
                table: "HighScores");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "HighScores");

            migrationBuilder.AddColumn<int>(
                name: "HighscoreId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_HighscoreId",
                table: "Games",
                column: "HighscoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_HighScores_HighscoreId",
                table: "Games",
                column: "HighscoreId",
                principalTable: "HighScores",
                principalColumn: "HighscoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
