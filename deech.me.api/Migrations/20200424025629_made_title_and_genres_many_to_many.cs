using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.Migrations
{
    public partial class made_title_and_genres_many_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TitleInfoGenres",
                columns: table => new
                {
                    TitleInfoId = table.Column<int>(nullable: false),
                    GenreCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleInfoGenres", x => new { x.TitleInfoId, x.GenreCode });
                    table.ForeignKey(
                        name: "FK_TitleInfoGenres_Genres_GenreCode",
                        column: x => x.GenreCode,
                        principalTable: "Genres",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleInfoGenres_TitleInfos_TitleInfoId",
                        column: x => x.TitleInfoId,
                        principalTable: "TitleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoGenres_GenreCode",
                table: "TitleInfoGenres",
                column: "GenreCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TitleInfoGenres");

            migrationBuilder.AddColumn<int>(
                name: "TitleInfoId",
                table: "Genres",
                type: "int",
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
    }
}
