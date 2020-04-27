using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.Migrations
{
    public partial class added_id_field_to_authors_and_translators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleInfoTranslators",
                table: "TitleInfoTranslators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleInfoAuthors",
                table: "TitleInfoAuthors");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TitleInfoTranslators",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TitleInfoAuthors",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleInfoTranslators",
                table: "TitleInfoTranslators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleInfoAuthors",
                table: "TitleInfoAuthors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoTranslators_TitleInfoId",
                table: "TitleInfoTranslators",
                column: "TitleInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfoAuthors_TitleInfoId",
                table: "TitleInfoAuthors",
                column: "TitleInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleInfoTranslators",
                table: "TitleInfoTranslators");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfoTranslators_TitleInfoId",
                table: "TitleInfoTranslators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleInfoAuthors",
                table: "TitleInfoAuthors");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfoAuthors_TitleInfoId",
                table: "TitleInfoAuthors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TitleInfoTranslators");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TitleInfoAuthors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleInfoTranslators",
                table: "TitleInfoTranslators",
                columns: new[] { "TitleInfoId", "TranslatorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleInfoAuthors",
                table: "TitleInfoAuthors",
                columns: new[] { "TitleInfoId", "AuthorId" });
        }
    }
}
