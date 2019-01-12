using Microsoft.EntityFrameworkCore.Migrations;

namespace RateYourEntertainment.Migrations
{
    public partial class GameModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameOfTheMonth",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GameOfTheMonth",
                table: "Games",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Games",
                nullable: true);
        }
    }
}
