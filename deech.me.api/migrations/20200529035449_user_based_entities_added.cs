using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.migrations
{
    public partial class user_based_entities_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "BookCollectionId",
                table: "TitleInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
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
                    UserInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCollections_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<string>(nullable: true),
                    ParagraphId = table.Column<int>(nullable: false),
                    UserInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookmarks_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookmarks_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleInfoId = table.Column<int>(nullable: false),
                    Created = table.Column<string>(nullable: true),
                    ParagraphId = table.Column<int>(nullable: false),
                    UserInfoId = table.Column<string>(nullable: true),
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
                        name: "FK_Citations_TitleInfos_TitleInfoId",
                        column: x => x.TitleInfoId,
                        principalTable: "TitleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citations_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    UserInfoId = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteBooks", x => new { x.BookId, x.UserInfoId });
                    table.ForeignKey(
                        name: "FK_FavouriteBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteBooks_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<string>(nullable: true),
                    ParagraphId = table.Column<int>(nullable: false),
                    UserInfoId = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReadingProgresses",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    UserInfoId = table.Column<string>(nullable: false),
                    Created = table.Column<string>(nullable: true),
                    Progress = table.Column<int>(nullable: false),
                    Updated = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingProgresses", x => new { x.BookId, x.UserInfoId });
                    table.ForeignKey(
                        name: "FK_ReadingProgresses_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadingProgresses_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_BookCollectionId",
                table: "TitleInfos",
                column: "BookCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserInfoId",
                table: "Comments",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCollections_UserInfoId",
                table: "BookCollections",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_ParagraphId",
                table: "Bookmarks",
                column: "ParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserInfoId",
                table: "Bookmarks",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_ParagraphId",
                table: "Citations",
                column: "ParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_TitleInfoId",
                table: "Citations",
                column: "TitleInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_UserInfoId",
                table: "Citations",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteBooks_UserInfoId",
                table: "FavouriteBooks",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ParagraphId",
                table: "Notes",
                column: "ParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserInfoId",
                table: "Notes",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingProgresses_UserInfoId",
                table: "ReadingProgresses",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserInfos_UserInfoId",
                table: "Comments",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_BookCollections_BookCollectionId",
                table: "TitleInfos",
                column: "BookCollectionId",
                principalTable: "BookCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserInfos_UserInfoId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_BookCollections_BookCollectionId",
                table: "TitleInfos");

            migrationBuilder.DropTable(
                name: "BookCollections");

            migrationBuilder.DropTable(
                name: "Bookmarks");

            migrationBuilder.DropTable(
                name: "Citations");

            migrationBuilder.DropTable(
                name: "FavouriteBooks");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "ReadingProgresses");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_BookCollectionId",
                table: "TitleInfos");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserInfoId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BookCollectionId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
