using Microsoft.EntityFrameworkCore.Migrations;

namespace RateYourEntertainment.Migrations
{
    public partial class ReviewScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewScore",
                table: "GameReviews",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewScore",
                table: "GameReviews");
        }
    }
}
