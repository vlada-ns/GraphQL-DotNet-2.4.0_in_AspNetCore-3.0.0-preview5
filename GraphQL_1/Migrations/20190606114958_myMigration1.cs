using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL_1.Migrations
{
    public partial class myMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    HouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.HouseId);
                });

            migrationBuilder.CreateTable(
                name: "Window",
                columns: table => new
                {
                    WindowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    HouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Window", x => x.WindowId);
                    table.ForeignKey(
                        name: "FK_Window_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "House",
                columns: new[] { "HouseId", "Name" },
                values: new object[,]
                {
                    { 1, "HouseName1" },
                    { 2, "HouseName2" },
                    { 3, "HouseName3" },
                    { 4, "HouseName4" },
                    { 5, "HouseName5" },
                    { 6, "HouseName6" },
                    { 7, "HouseName7" },
                    { 8, "HouseName8" },
                    { 9, "HouseName9" },
                    { 10, "HouseName10" }
                });

            migrationBuilder.InsertData(
                table: "Window",
                columns: new[] { "WindowId", "HouseId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "WindowName1" },
                    { 2, 2, "WindowName2" },
                    { 3, 2, "WindowName3" },
                    { 4, 3, "WindowName4" },
                    { 5, 3, "WindowName5" },
                    { 6, 3, "WindowName6" },
                    { 7, 4, "WindowName7" },
                    { 8, 4, "WindowName8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Window_HouseId",
                table: "Window",
                column: "HouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Window");

            migrationBuilder.DropTable(
                name: "House");
        }
    }
}
