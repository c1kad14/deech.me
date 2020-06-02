using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.migrations
{
    public partial class removed_user_info_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCollections_UserInfos_UserInfoId",
                table: "BookCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_UserInfos_UserInfoId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Citations_TitleInfos_TitleInfoId",
                table: "Citations");

            migrationBuilder.DropForeignKey(
                name: "FK_Citations_UserInfos_UserInfoId",
                table: "Citations");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserInfos_UserInfoId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteBooks_UserInfos_UserInfoId",
                table: "FavouriteBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_UserInfos_UserInfoId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadingProgresses_UserInfos_UserInfoId",
                table: "ReadingProgresses");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadingProgresses",
                table: "ReadingProgresses");

            migrationBuilder.DropIndex(
                name: "IX_ReadingProgresses_UserInfoId",
                table: "ReadingProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_ParagraphId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserInfoId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteBooks",
                table: "FavouriteBooks");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteBooks_UserInfoId",
                table: "FavouriteBooks");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserInfoId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Citations_TitleInfoId",
                table: "Citations");

            migrationBuilder.DropIndex(
                name: "IX_Citations_UserInfoId",
                table: "Citations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_ParagraphId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_UserInfoId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_BookCollections_UserInfoId",
                table: "BookCollections");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "ReadingProgresses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "FavouriteBooks");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "FavouriteBooks");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TitleInfoId",
                table: "Citations");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Citations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "BookCollections");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ReadingProgresses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Notes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FavouriteBooks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Created",
                table: "FavouriteBooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Citations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bookmarks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BookCollections",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadingProgresses",
                table: "ReadingProgresses",
                columns: new[] { "BookId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                columns: new[] { "ParagraphId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteBooks",
                table: "FavouriteBooks",
                columns: new[] { "BookId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                columns: new[] { "ParagraphId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadingProgresses",
                table: "ReadingProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteBooks",
                table: "FavouriteBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReadingProgresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FavouriteBooks");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "FavouriteBooks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Citations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookCollections");

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "ReadingProgresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "Notes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "FavouriteBooks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "FavouriteBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TitleInfoId",
                table: "Citations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "Citations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Bookmarks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "Bookmarks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "BookCollections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadingProgresses",
                table: "ReadingProgresses",
                columns: new[] { "BookId", "UserInfoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteBooks",
                table: "FavouriteBooks",
                columns: new[] { "BookId", "UserInfoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReadingProgresses_UserInfoId",
                table: "ReadingProgresses",
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
                name: "IX_FavouriteBooks_UserInfoId",
                table: "FavouriteBooks",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserInfoId",
                table: "Comments",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_TitleInfoId",
                table: "Citations",
                column: "TitleInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_UserInfoId",
                table: "Citations",
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
                name: "IX_BookCollections_UserInfoId",
                table: "BookCollections",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollections_UserInfos_UserInfoId",
                table: "BookCollections",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_UserInfos_UserInfoId",
                table: "Bookmarks",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citations_TitleInfos_TitleInfoId",
                table: "Citations",
                column: "TitleInfoId",
                principalTable: "TitleInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citations_UserInfos_UserInfoId",
                table: "Citations",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserInfos_UserInfoId",
                table: "Comments",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteBooks_UserInfos_UserInfoId",
                table: "FavouriteBooks",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_UserInfos_UserInfoId",
                table: "Notes",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingProgresses_UserInfos_UserInfoId",
                table: "ReadingProgresses",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
