using Microsoft.EntityFrameworkCore.Migrations;

namespace HighScore.Website.Migrations
{
    public partial class UpdateDatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Game",
                table: "HighScores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Game",
                table: "HighScores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
