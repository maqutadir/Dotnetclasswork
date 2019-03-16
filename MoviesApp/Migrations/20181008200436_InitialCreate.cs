using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MusicDirector = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: false),
                    Featuring = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    DateOfRecording = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    NoOfMoviesProduced = table.Column<int>(nullable: false),
                    Isreputed = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    FoundedIn = table.Column<int>(nullable: false),
                    Area = table.Column<decimal>(nullable: false),
                    NoOfMoviesShot = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodMovies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ProducerId = table.Column<int>(nullable: false),
                    StudioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodMovies_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodMovies_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Budget = table.Column<int>(nullable: false),
                    BOCollection = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    DateofRelease = table.Column<DateTime>(nullable: false),
                    Isrecommended = table.Column<bool>(nullable: false),
                    DateLastPlayed = table.Column<DateTime>(nullable: true),
                    ProducerId = table.Column<int>(nullable: false),
                    StudioId = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodMovies_ProducerId",
                table: "GoodMovies",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodMovies_StudioId",
                table: "GoodMovies",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_AlbumId",
                table: "Movies",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProducerId",
                table: "Movies",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_StudioId",
                table: "Movies",
                column: "StudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodMovies");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
