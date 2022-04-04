using Microsoft.EntityFrameworkCore.Migrations;

namespace HighScore.Website.Migrations
{
    public partial class UpdateDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HighScores_Games_GameId",
                table: "HighScores");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "HighScores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Game",
                table: "HighScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_HighScores_Games_GameId",
                table: "HighScores",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HighScores_Games_GameId",
                table: "HighScores");

            migrationBuilder.DropColumn(
                name: "Game",
                table: "HighScores");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "HighScores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HighScores_Games_GameId",
                table: "HighScores",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
