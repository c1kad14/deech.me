using Microsoft.EntityFrameworkCore.Migrations;

namespace deech.me.api.Migrations
{
    public partial class added_file_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Books");
        }
    }
}
