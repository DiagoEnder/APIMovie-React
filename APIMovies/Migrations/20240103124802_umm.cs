using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMovies.Migrations
{
    /// <inheritdoc />
    public partial class umm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_IdMovie",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_IdMovie",
                table: "Comments",
                column: "IdMovie",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_IdMovie",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_IdMovie",
                table: "Comments",
                column: "IdMovie",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
