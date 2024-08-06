using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuDays",
                columns: table => new
                {
                    MenuDayId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    DayOfWeek = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuDays", x => new { x.MenuDayId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_MenuDays_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuDayId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RecipeDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    RecipeImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MealType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => new { x.MealId, x.MenuDayId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_Meals_MenuDays_MenuDayId_MenuId",
                        columns: x => new { x.MenuDayId, x.MenuId },
                        principalTable: "MenuDays",
                        principalColumns: new[] { "MenuDayId", "MenuId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MenuDayId_MenuId",
                table: "Meals",
                columns: new[] { "MenuDayId", "MenuId" });

            migrationBuilder.CreateIndex(
                name: "IX_MenuDays_MenuId",
                table: "MenuDays",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "MenuDays");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
