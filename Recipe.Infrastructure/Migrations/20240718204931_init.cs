using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PolishName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Calories = table.Column<decimal>(type: "numeric", nullable: false),
                    Cholesterol = table.Column<decimal>(type: "numeric", nullable: false),
                    FatSaturated = table.Column<decimal>(type: "numeric", nullable: false),
                    FatTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Potassium = table.Column<decimal>(type: "numeric", nullable: false),
                    Protein = table.Column<decimal>(type: "numeric", nullable: false),
                    Sodium = table.Column<decimal>(type: "numeric", nullable: false),
                    Sugar = table.Column<decimal>(type: "numeric", nullable: false),
                    Measurement_Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Measurement_Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AvarageRating = table.Column<float>(type: "real", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    VideoUrl = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeSections",
                columns: table => new
                {
                    RecipeSectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSections", x => new { x.RecipeSectionId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeSections_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeSteps",
                columns: table => new
                {
                    RecipeStepId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ImgUrl = table.Column<string>(type: "text", nullable: false),
                    VideoUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSteps", x => new { x.RecipeStepId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeSteps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeIngredientId = table.Column<string>(type: "text", nullable: false),
                    RecipeSectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeIngredientId, x.RecipeSectionId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_RecipeSections_RecipeSectionId_RecipeId",
                        columns: x => new { x.RecipeSectionId, x.RecipeId },
                        principalTable: "RecipeSections",
                        principalColumns: new[] { "RecipeSectionId", "RecipeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeSectionId_RecipeId",
                table: "RecipeIngredients",
                columns: new[] { "RecipeSectionId", "RecipeId" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSections_RecipeId",
                table: "RecipeSections",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeSteps");

            migrationBuilder.DropTable(
                name: "RecipeSections");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
