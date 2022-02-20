using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroceryList.Migrations
{
    public partial class Grocerys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Grocerys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<double>(nullable: false),
                    CategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grocerys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grocerys_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "F", "Frozen" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "N", "Not Frozen" });

            migrationBuilder.InsertData(
                table: "Grocerys",
                columns: new[] { "Id", "CategoryId", "Name", "UnitPrice" },
                values: new object[] { 1, "F", "Steak", 19.5 });

            migrationBuilder.InsertData(
                table: "Grocerys",
                columns: new[] { "Id", "CategoryId", "Name", "UnitPrice" },
                values: new object[] { 2, "N", "Cereal", 2.9900000000000002 });

            migrationBuilder.CreateIndex(
                name: "IX_Grocerys_CategoryId",
                table: "Grocerys",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grocerys");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
