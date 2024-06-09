using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Infrastructure.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Measurement_Name = table.Column<int>(type: "integer", nullable: false),
                    Measurement_Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Calories = table.Column<decimal>(type: "numeric", nullable: false),
                    Cholesterol = table.Column<decimal>(type: "numeric", nullable: false),
                    FatSaturated = table.Column<decimal>(type: "numeric", nullable: false),
                    FatTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PolishName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Potassium = table.Column<decimal>(type: "numeric", nullable: false),
                    Protein = table.Column<decimal>(type: "numeric", nullable: false),
                    Sodium = table.Column<decimal>(type: "numeric", nullable: false),
                    Sugar = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });
        }
    }
}
