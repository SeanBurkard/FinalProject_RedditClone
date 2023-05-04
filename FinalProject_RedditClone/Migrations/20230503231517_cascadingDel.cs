using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject_RedditClone.Migrations
{
    public partial class cascadingDel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Forum_ForumId",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Posts_PostId",
                table: "Vote");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Forum_ForumId",
                table: "Vote",
                column: "ForumId",
                principalTable: "Forum",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Posts_PostId",
                table: "Vote",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Forum_ForumId",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Posts_PostId",
                table: "Vote");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Forum_ForumId",
                table: "Vote",
                column: "ForumId",
                principalTable: "Forum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Posts_PostId",
                table: "Vote",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
