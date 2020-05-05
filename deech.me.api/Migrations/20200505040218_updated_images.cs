using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.Migrations
{
    public partial class updated_images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleInfos_Covers_CoverId",
                table: "TitleInfos");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropIndex(
                name: "IX_TitleInfos_CoverId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "CoverId",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "TitleInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "TitleInfos");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "CoverId",
                table: "TitleInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Images",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TitleInfos_CoverId",
                table: "TitleInfos",
                column: "CoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleInfos_Covers_CoverId",
                table: "TitleInfos",
                column: "CoverId",
                principalTable: "Covers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
