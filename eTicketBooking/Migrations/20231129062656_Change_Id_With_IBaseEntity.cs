using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTicketBooking.Migrations
{
    /// <inheritdoc />
    public partial class Change_Id_With_IBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsActorId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MoviesMovieId",
                table: "ActorMovie");

            migrationBuilder.RenameColumn(
                name: "ProducerId",
                table: "Producers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Cinemas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "Actors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MoviesMovieId",
                table: "ActorMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "ActorsActorId",
                table: "ActorMovie",
                newName: "ActorsId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MoviesMovieId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                table: "ActorMovie",
                column: "ActorsId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MoviesId",
                table: "ActorMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MoviesId",
                table: "ActorMovie");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Producers",
                newName: "ProducerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cinemas",
                newName: "CinemaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Actors",
                newName: "ActorId");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "ActorMovie",
                newName: "MoviesMovieId");

            migrationBuilder.RenameColumn(
                name: "ActorsId",
                table: "ActorMovie",
                newName: "ActorsActorId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MoviesId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MoviesMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsActorId",
                table: "ActorMovie",
                column: "ActorsActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MoviesMovieId",
                table: "ActorMovie",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
