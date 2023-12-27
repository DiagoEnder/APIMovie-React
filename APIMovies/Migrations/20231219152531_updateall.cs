using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMovies.Migrations
{
    /// <inheritdoc />
    public partial class updateall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Movies",
                newName: "TypeMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_TypeMovieId",
                table: "Movies",
                column: "TypeMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Types_TypeMovieId",
                table: "Movies",
                column: "TypeMovieId",
                principalTable: "Types",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Types_TypeMovieId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_TypeMovieId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "TypeMovieId",
                table: "Movies",
                newName: "Rating");
        }
    }
}
