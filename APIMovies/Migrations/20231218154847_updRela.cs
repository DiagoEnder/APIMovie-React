using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMovies.Migrations
{
    /// <inheritdoc />
    public partial class updRela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserInfoId",
                table: "Comments",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_userInfos_UserInfoId",
                table: "Comments",
                column: "UserInfoId",
                principalTable: "userInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_userInfos_UserInfoId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserInfoId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Comments");
        }
    }
}
