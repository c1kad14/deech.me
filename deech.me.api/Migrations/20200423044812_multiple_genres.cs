using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.Migrations
{
    public partial class multiple_genres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_Genres_GenreId",
                table: "TitleInfos");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_GenreId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "TitleInfos");

            migrationBuilder.AddColumn<int>(
                name: "TitleInfoId",
                table: "Genres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_TitleInfoId",
                table: "Genres",
                column: "TitleInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_TitleInfos_TitleInfoId",
                table: "Genres",
                column: "TitleInfoId",
                principalTable: "TitleInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_TitleInfos_TitleInfoId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_TitleInfoId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "TitleInfoId",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "TitleInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_GenreId",
                table: "TitleInfos",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_Genres_GenreId",
                table: "TitleInfos",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
