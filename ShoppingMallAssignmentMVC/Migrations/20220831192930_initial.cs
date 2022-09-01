using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingMallAssignmentMVC.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    PanNumber = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    RoleName = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminModels_Email",
                table: "AdminModels",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminModels");
        }
    }
}
