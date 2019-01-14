using Microsoft.EntityFrameworkCore.Migrations;

namespace RateYourEntertainment.Migrations
{
    public partial class AddingUserIdToReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "GameReviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameReviews_ApplicationUserId",
                table: "GameReviews",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameReviews_AspNetUsers_ApplicationUserId",
                table: "GameReviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameReviews_AspNetUsers_ApplicationUserId",
                table: "GameReviews");

            migrationBuilder.DropIndex(
                name: "IX_GameReviews_ApplicationUserId",
                table: "GameReviews");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "GameReviews");
        }
    }
}
