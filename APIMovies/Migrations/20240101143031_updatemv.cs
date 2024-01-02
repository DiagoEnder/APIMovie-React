using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMovies.Migrations
{
    /// <inheritdoc />
    public partial class updatemv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MoviesId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MoviesId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdMovie",
                table: "Comments",
                column: "IdMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_IdMovie",
                table: "Comments",
                column: "IdMovie",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_IdMovie",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IdMovie",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MoviesId",
                table: "Comments",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MoviesId",
                table: "Comments",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
