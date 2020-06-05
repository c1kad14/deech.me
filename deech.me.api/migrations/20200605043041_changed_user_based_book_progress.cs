using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.migrations
{
    public partial class changed_user_based_book_progress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadingProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Citations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bookmarks");

            migrationBuilder.AddColumn<int>(
                name: "UserBookId",
                table: "Notes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserBookId1",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserBookId",
                table: "Citations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserBookId1",
                table: "Citations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserBookId",
                table: "Bookmarks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserBookId1",
                table: "Bookmarks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                columns: new[] { "ParagraphId", "UserBookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                columns: new[] { "ParagraphId", "UserBookId" });

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
                    UserId = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserBookId",
                table: "Notes",
                column: "UserBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserBookId1",
                table: "Notes",
                column: "UserBookId1");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_UserBookId",
                table: "Citations",
                column: "UserBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_UserBookId1",
                table: "Citations",
                column: "UserBookId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserBookId",
                table: "Bookmarks",
                column: "UserBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserBookId1",
                table: "Bookmarks",
                column: "UserBookId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_BookId_UserId",
                table: "UserBooks",
                columns: new[] { "BookId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_UserBooks_UserBookId",
                table: "Bookmarks",
                column: "UserBookId",
                principalTable: "UserBooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_UserBooks_UserBookId1",
                table: "Bookmarks",
                column: "UserBookId1",
                principalTable: "UserBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citations_UserBooks_UserBookId",
                table: "Citations",
                column: "UserBookId",
                principalTable: "UserBooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Citations_UserBooks_UserBookId1",
                table: "Citations",
                column: "UserBookId1",
                principalTable: "UserBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_UserBooks_UserBookId",
                table: "Notes",
                column: "UserBookId",
                principalTable: "UserBooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_UserBooks_UserBookId1",
                table: "Notes",
                column: "UserBookId1",
                principalTable: "UserBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_UserBooks_UserBookId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_UserBooks_UserBookId1",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Citations_UserBooks_UserBookId",
                table: "Citations");

            migrationBuilder.DropForeignKey(
                name: "FK_Citations_UserBooks_UserBookId1",
                table: "Citations");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_UserBooks_UserBookId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_UserBooks_UserBookId1",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "UserBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserBookId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserBookId1",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Citations_UserBookId",
                table: "Citations");

            migrationBuilder.DropIndex(
                name: "IX_Citations_UserBookId1",
                table: "Citations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_UserBookId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_UserBookId1",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "UserBookId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserBookId1",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserBookId",
                table: "Citations");

            migrationBuilder.DropColumn(
                name: "UserBookId1",
                table: "Citations");

            migrationBuilder.DropColumn(
                name: "UserBookId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "UserBookId1",
                table: "Bookmarks");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Notes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Citations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bookmarks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                columns: new[] { "ParagraphId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                columns: new[] { "ParagraphId", "UserId" });

            migrationBuilder.CreateTable(
                name: "ReadingProgresses",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingProgresses", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ReadingProgresses_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
