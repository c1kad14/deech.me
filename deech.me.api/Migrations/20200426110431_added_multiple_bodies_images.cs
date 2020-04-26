using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.Migrations
{
    public partial class added_multiple_bodies_images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookContents_ContentId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_PublishInfos_PublishId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_TitleInfos_TitleId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_Persons_AuthorId",
                table: "TitleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_Persons_TranslatorId",
                table: "TitleInfos");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_AuthorId",
                table: "TitleInfos");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_TranslatorId",
                table: "TitleInfos");

            migrationBuilder.DropIndex(
                name: "IX_Books_ContentId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublishId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_TitleId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "TranslatorId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublishId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "BookContents");

            migrationBuilder.AddColumn<int>(
                name: "CoverId",
                table: "TitleInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomInfoId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublishInfoId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TitleInfoId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookContents",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "BookContents",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    Data = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "TitleInfoAuthors",
                columns: table => new
                {
                    TitleInfoId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleInfoAuthors", x => new { x.TitleInfoId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_TitleInfoAuthors_Persons_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Persons",
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
                name: "TitleInfoTranslators",
                columns: table => new
                {
                    TitleInfoId = table.Column<int>(nullable: false),
                    TranslatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleInfoTranslators", x => new { x.TitleInfoId, x.TranslatorId });
                    table.ForeignKey(
                        name: "FK_TitleInfoTranslators_TitleInfos_TitleInfoId",
                        column: x => x.TitleInfoId,
                        principalTable: "TitleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleInfoTranslators_Persons_TranslatorId",
                        column: x => x.TranslatorId,
                        principalTable: "Persons",
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

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_CoverId",
                table: "TitleInfos",
                column: "CoverId");

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
                name: "IX_BookContents_BookId",
                table: "BookContents",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_BookId",
                table: "Images",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoAuthors_AuthorId",
                table: "TitleInfoAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoKeywords_KeywordCode",
                table: "TitleInfoKeywords",
                column: "KeywordCode");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoTranslators_TranslatorId",
                table: "TitleInfoTranslators",
                column: "TranslatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookContents_Books_BookId",
                table: "BookContents",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_CustomInfos_CustomInfoId",
                table: "Books",
                column: "CustomInfoId",
                principalTable: "CustomInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PublishInfos_PublishInfoId",
                table: "Books",
                column: "PublishInfoId",
                principalTable: "PublishInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_TitleInfos_TitleInfoId",
                table: "Books",
                column: "TitleInfoId",
                principalTable: "TitleInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_Covers_CoverId",
                table: "TitleInfos",
                column: "CoverId",
                principalTable: "Covers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookContents_Books_BookId",
                table: "BookContents");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_CustomInfos_CustomInfoId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_PublishInfos_PublishInfoId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_TitleInfos_TitleInfoId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_Covers_CoverId",
                table: "TitleInfos");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropTable(
                name: "CustomInfos");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "TitleInfoAuthors");

            migrationBuilder.DropTable(
                name: "TitleInfoKeywords");

            migrationBuilder.DropTable(
                name: "TitleInfoTranslators");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_CoverId",
                table: "TitleInfos");

            migrationBuilder.DropIndex(
                name: "IX_Books_CustomInfoId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublishInfoId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_TitleInfoId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_BookContents_BookId",
                table: "BookContents");

            migrationBuilder.DropColumn(
                name: "CoverId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "CustomInfoId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublishInfoId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TitleInfoId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookContents");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "BookContents");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "TitleInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "TitleInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TranslatorId",
                table: "TitleInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublishId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "BookContents",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_AuthorId",
                table: "TitleInfos",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_TranslatorId",
                table: "TitleInfos",
                column: "TranslatorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookContents_ContentId",
                table: "Books",
                column: "ContentId",
                principalTable: "BookContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PublishInfos_PublishId",
                table: "Books",
                column: "PublishId",
                principalTable: "PublishInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_TitleInfos_TitleId",
                table: "Books",
                column: "TitleId",
                principalTable: "TitleInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_Persons_AuthorId",
                table: "TitleInfos",
                column: "AuthorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_Persons_TranslatorId",
                table: "TitleInfos",
                column: "TranslatorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
