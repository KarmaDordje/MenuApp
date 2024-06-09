using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Infrastructure.Migrations
{
    public partial class AddedNewColumnsToRecipeStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "RecipeSteps",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "RecipeSteps",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "RecipeSteps");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "RecipeSteps");
        }
    }
}
