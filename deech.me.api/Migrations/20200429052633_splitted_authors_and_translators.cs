using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.Migrations
{
    public partial class splitted_authors_and_translators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfoAuthors_Persons_AuthorId",
                table: "TitleInfoAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfoTranslators_Persons_TranslatorId",
                table: "TitleInfoTranslators");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropColumn(
                name: "Annotation",
                table: "TitleInfos");

            migrationBuilder.AddColumn<int>(
                name: "AnnotationId",
                table: "TitleInfos",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_AnnotationId",
                table: "TitleInfos",
                column: "AnnotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfoAuthors_Authors_AuthorId",
                table: "TitleInfoAuthors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_Annotations_AnnotationId",
                table: "TitleInfos",
                column: "AnnotationId",
                principalTable: "Annotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfoTranslators_Translators_TranslatorId",
                table: "TitleInfoTranslators",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfoAuthors_Authors_AuthorId",
                table: "TitleInfoAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_Annotations_AnnotationId",
                table: "TitleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfoTranslators_Translators_TranslatorId",
                table: "TitleInfoTranslators");

            migrationBuilder.DropTable(
                name: "Annotations");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Translators");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_AnnotationId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "AnnotationId",
                table: "TitleInfos");

            migrationBuilder.AddColumn<string>(
                name: "Annotation",
                table: "TitleInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfoAuthors_Persons_AuthorId",
                table: "TitleInfoAuthors",
                column: "AuthorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfoTranslators_Persons_TranslatorId",
                table: "TitleInfoTranslators",
                column: "TranslatorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
