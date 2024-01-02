using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMovies.Migrations
{
    /// <inheritdoc />
    public partial class updateuser3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserInfo_UserInfoId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserInfoId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IdUser",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdUser",
                table: "Comments",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserInfo_IdUser",
                table: "Comments",
                column: "IdUser",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserInfo_IdUser",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IdUser",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdUser",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                name: "FK_Comments_UserInfo_UserInfoId",
                table: "Comments",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id");
        }
    }
}
