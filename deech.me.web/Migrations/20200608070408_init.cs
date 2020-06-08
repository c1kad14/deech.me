using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annotations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annotations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCollections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Updated = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCollections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PublishInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
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
                name: "Translators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TitleInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AnnotationId = table.Column<int>(nullable: true),
                    Cover = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    LanguageCode = table.Column<string>(nullable: true),
                    SourceLanguageCode = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    BookCollectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitleInfos_Annotations_AnnotationId",
                        column: x => x.AnnotationId,
                        principalTable: "Annotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TitleInfos_BookCollections_BookCollectionId",
                        column: x => x.BookCollectionId,
                        principalTable: "BookCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TitleInfos_Languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TitleInfos_Languages_SourceLanguageCode",
                        column: x => x.SourceLanguageCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CustomInfoId = table.Column<int>(nullable: true),
                    PublishInfoId = table.Column<int>(nullable: true),
                    TitleInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_CustomInfos_CustomInfoId",
                        column: x => x.CustomInfoId,
                        principalTable: "CustomInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_PublishInfos_PublishInfoId",
                        column: x => x.PublishInfoId,
                        principalTable: "PublishInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_TitleInfos_TitleInfoId",
                        column: x => x.TitleInfoId,
                        principalTable: "TitleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TitleInfoAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleInfoId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleInfoAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitleInfoAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleInfoAuthors_TitleInfos_TitleInfoId",
                        column: x => x.TitleInfoId,
                        principalTable: "TitleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "TitleInfoKeywords",
                columns: table => new
                {
                    TitleInfoId = table.Column<int>(nullable: false),
                    KeywordCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleInfoKeywords", x => new { x.TitleInfoId, x.KeywordCode });
                    table.ForeignKey(
                        name: "FK_TitleInfoKeywords_Keywords_KeywordCode",
                        column: x => x.KeywordCode,
                        principalTable: "Keywords",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleInfoKeywords_TitleInfos_TitleInfoId",
                        column: x => x.TitleInfoId,
                        principalTable: "TitleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TitleInfoTranslators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleInfoId = table.Column<int>(nullable: false),
                    TranslatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleInfoTranslators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitleInfoTranslators_TitleInfos_TitleInfoId",
                        column: x => x.TitleInfoId,
                        principalTable: "TitleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleInfoTranslators_Translators_TranslatorId",
                        column: x => x.TranslatorId,
                        principalTable: "Translators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    Created = table.Column<string>(nullable: true),
                    Progress = table.Column<int>(nullable: false),
                    Updated = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Favourite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssociatedId = table.Column<int>(nullable: true),
                    Created = table.Column<string>(nullable: true),
                    ParagraphId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_AssociatedId",
                        column: x => x.AssociatedId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    ParagraphId = table.Column<int>(nullable: false),
                    UserBookId = table.Column<int>(nullable: false),
                    Created = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => new { x.ParagraphId, x.UserBookId });
                    table.ForeignKey(
                        name: "FK_Bookmarks_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookmarks_UserBooks_UserBookId",
                        column: x => x.UserBookId,
                        principalTable: "UserBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Citations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<string>(nullable: true),
                    ParagraphId = table.Column<int>(nullable: false),
                    UserBookId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citations_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citations_UserBooks_UserBookId",
                        column: x => x.UserBookId,
                        principalTable: "UserBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ParagraphId = table.Column<int>(nullable: false),
                    UserBookId = table.Column<int>(nullable: false),
                    Created = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => new { x.ParagraphId, x.UserBookId });
                    table.ForeignKey(
                        name: "FK_Notes_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_UserBooks_UserBookId",
                        column: x => x.UserBookId,
                        principalTable: "UserBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserBookId",
                table: "Bookmarks",
                column: "UserBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CustomInfoId",
                table: "Books",
                column: "CustomInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishInfoId",
                table: "Books",
                column: "PublishInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TitleInfoId",
                table: "Books",
                column: "TitleInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_UserBookId",
                table: "Citations",
                column: "UserBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_ParagraphId_UserBookId",
                table: "Citations",
                columns: new[] { "ParagraphId", "UserBookId" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AssociatedId",
                table: "Comments",
                column: "AssociatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParagraphId",
                table: "Comments",
                column: "ParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserBookId",
                table: "Notes",
                column: "UserBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_BookId",
                table: "Paragraphs",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoAuthors_AuthorId",
                table: "TitleInfoAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoAuthors_TitleInfoId",
                table: "TitleInfoAuthors",
                column: "TitleInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoGenres_GenreCode",
                table: "TitleInfoGenres",
                column: "GenreCode");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoKeywords_KeywordCode",
                table: "TitleInfoKeywords",
                column: "KeywordCode");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_AnnotationId",
                table: "TitleInfos",
                column: "AnnotationId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_BookCollectionId",
                table: "TitleInfos",
                column: "BookCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_LanguageCode",
                table: "TitleInfos",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_SourceLanguageCode",
                table: "TitleInfos",
                column: "SourceLanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoTranslators_TitleInfoId",
                table: "TitleInfoTranslators",
                column: "TitleInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoTranslators_TranslatorId",
                table: "TitleInfoTranslators",
                column: "TranslatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_BookId_UserId",
                table: "UserBooks",
                columns: new[] { "BookId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmarks");

            migrationBuilder.DropTable(
                name: "Citations");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "TitleInfoAuthors");

            migrationBuilder.DropTable(
                name: "TitleInfoGenres");

            migrationBuilder.DropTable(
                name: "TitleInfoKeywords");

            migrationBuilder.DropTable(
                name: "TitleInfoTranslators");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropTable(
                name: "UserBooks");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "Translators");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "CustomInfos");

            migrationBuilder.DropTable(
                name: "PublishInfos");

            migrationBuilder.DropTable(
                name: "TitleInfos");

            migrationBuilder.DropTable(
                name: "Annotations");

            migrationBuilder.DropTable(
                name: "BookCollections");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
