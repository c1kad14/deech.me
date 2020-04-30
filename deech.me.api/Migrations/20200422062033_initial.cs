using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublishInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TitleInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Annotation = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    Cover = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true),
                    SourceLanguageId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TranslatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitleInfos_Persons_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TitleInfos_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TitleInfos_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TitleInfos_Languages_SourceLanguageId",
                        column: x => x.SourceLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TitleInfos_Persons_TranslatorId",
                        column: x => x.TranslatorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(nullable: true),
                    PublishId = table.Column<int>(nullable: true),
                    TitleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookContents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "BookContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_PublishInfos_PublishId",
                        column: x => x.PublishId,
                        principalTable: "PublishInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_TitleInfos_TitleId",
                        column: x => x.TitleId,
                        principalTable: "TitleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ContentId",
                table: "Books",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishId",
                table: "Books",
                column: "PublishId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TitleId",
                table: "Books",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_AuthorId",
                table: "TitleInfos",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_GenreId",
                table: "TitleInfos",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_LanguageId",
                table: "TitleInfos",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_SourceLanguageId",
                table: "TitleInfos",
                column: "SourceLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_TranslatorId",
                table: "TitleInfos",
                column: "TranslatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookContents");

            migrationBuilder.DropTable(
                name: "PublishInfos");

            migrationBuilder.DropTable(
                name: "TitleInfos");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
