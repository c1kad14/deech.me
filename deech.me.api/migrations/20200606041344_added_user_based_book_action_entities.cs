using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.migrations
{
    public partial class added_user_based_book_action_entities : Migration
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
                name: "UserId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Comments",
                nullable: true);

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
                name: "IX_TitleInfos_BookCollectionId",
                table: "TitleInfos",
                column: "BookCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserBookId",
                table: "Bookmarks",
                column: "UserBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_UserBookId",
                table: "Citations",
                column: "UserBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_ParagraphId_UserBookId",
                table: "Citations",
                columns: new[] { "ParagraphId", "UserBookId" });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserBookId",
                table: "Notes",
                column: "UserBookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_BookId_UserId",
                table: "UserBooks",
                columns: new[] { "BookId", "UserId" });

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
                name: "FK_TitleInfos_BookCollections_BookCollectionId",
                table: "TitleInfos");

            migrationBuilder.DropTable(
                name: "BookCollections");

            migrationBuilder.DropTable(
                name: "Bookmarks");

            migrationBuilder.DropTable(
                name: "Citations");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "UserBooks");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_BookCollectionId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "BookCollectionId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Comments");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
