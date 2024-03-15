using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Recipe.Infrastructure.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Calories = table.Column<decimal>(type: "numeric", nullable: false),
                    Cholesterol = table.Column<decimal>(type: "numeric", nullable: false),
                    FatSaturated = table.Column<decimal>(type: "numeric", nullable: false),
                    FatTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    MeasuresType = table.Column<int>(type: "integer", nullable: false),
                    Potassium = table.Column<decimal>(type: "numeric", nullable: false),
                    Protein = table.Column<decimal>(type: "numeric", nullable: false),
                    Sodium = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
