using Microsoft.EntityFrameworkCore.Migrations;

namespace F1News.Migrations
{
    public partial class GalleryImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "GalleryImages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caption",
                table: "GalleryImages");
        }
    }
}
