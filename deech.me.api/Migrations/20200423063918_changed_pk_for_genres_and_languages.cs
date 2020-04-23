using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.Migrations
{
    public partial class changed_pk_for_genres_and_languages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_Languages_LanguageId",
                table: "TitleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_Languages_SourceLanguageId",
                table: "TitleInfos");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_LanguageId",
                table: "TitleInfos");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_SourceLanguageId",
                table: "TitleInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "SourceLanguageId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Genres");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "TitleInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceLanguageCode",
                table: "TitleInfos",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Languages",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Genres",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_LanguageCode",
                table: "TitleInfos",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_SourceLanguageCode",
                table: "TitleInfos",
                column: "SourceLanguageCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_Languages_LanguageCode",
                table: "TitleInfos",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_Languages_SourceLanguageCode",
                table: "TitleInfos",
                column: "SourceLanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_Languages_LanguageCode",
                table: "TitleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_Languages_SourceLanguageCode",
                table: "TitleInfos");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_LanguageCode",
                table: "TitleInfos");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_SourceLanguageCode",
                table: "TitleInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "SourceLanguageCode",
                table: "TitleInfos");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TitleInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceLanguageId",
                table: "TitleInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_LanguageId",
                table: "TitleInfos",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_SourceLanguageId",
                table: "TitleInfos",
                column: "SourceLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_Languages_LanguageId",
                table: "TitleInfos",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_Languages_SourceLanguageId",
                table: "TitleInfos",
                column: "SourceLanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
