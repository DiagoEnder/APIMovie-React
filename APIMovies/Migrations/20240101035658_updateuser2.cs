using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMovies.Migrations
{
    /// <inheritdoc />
    public partial class updateuser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_userInfos_UserInfoId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userInfos",
                table: "userInfos");

            migrationBuilder.RenameTable(
                name: "userInfos",
                newName: "UserInfo");

            migrationBuilder.AlterColumn<string>(
                name: "IdUser",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserInfo_UserInfoId",
                table: "Comments",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserInfo_UserInfoId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "userInfos");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userInfos",
                table: "userInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_userInfos_UserInfoId",
                table: "Comments",
                column: "UserInfoId",
                principalTable: "userInfos",
                principalColumn: "Id");
        }
    }
}
