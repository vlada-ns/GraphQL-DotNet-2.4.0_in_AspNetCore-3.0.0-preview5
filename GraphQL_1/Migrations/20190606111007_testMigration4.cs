using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL_1.Migrations
{
    public partial class testMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GradeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    GradeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName" },
                values: new object[,]
                {
                    { 1, "Matematika" },
                    { 2, "Srpski" },
                    { 3, "Likovno" },
                    { 4, "Geografija" },
                    { 5, "Fizika" },
                    { 6, "Fizicko" },
                    { 7, "Muzicko" },
                    { 8, "Informatika" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "GradeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Nikola" },
                    { 2, 2, "Vladimir" },
                    { 3, 2, "Dario" },
                    { 4, 3, "Srdjan" },
                    { 5, 3, "Boris" },
                    { 6, 3, "Milan" },
                    { 7, 4, "Milena" },
                    { 8, 4, "Milica" },
                    { 9, 4, "Jelena" },
                    { 10, 4, "Sonja" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                table: "Students",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
