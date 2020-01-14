using Microsoft.EntityFrameworkCore.Migrations;

namespace MayMeow.Blog.Data.Migrations
{
    public partial class NodesFeaturedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeaturedImage",
                table: "Nodes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeaturedImage",
                table: "Nodes");
        }
    }
}
