using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingMallAssignmentDB.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingMallModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingMallName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    ShoppingMallCity = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    ShoppingMallState = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    YearBuilt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingMallModels", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingMallModels_ShoppingMallName",
                table: "ShoppingMallModels",
                column: "ShoppingMallName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingMallModels");
        }
    }
}
