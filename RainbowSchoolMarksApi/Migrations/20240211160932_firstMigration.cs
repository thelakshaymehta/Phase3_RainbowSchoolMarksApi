using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RainbowSchoolMarksApi.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentMark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMark_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMark_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "alice.johnson@example.com", "Alice Johnson" },
                    { 2, "bob.smith@example.com", "Bob Smith" },
                    { 3, "carol.taylor@example.com", "Carol Taylor" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Credits", "Name" },
                values: new object[,]
                {
                    { 1, 4, "Mathematics" },
                    { 2, 3, "English Literature" },
                    { 3, 4, "Physics" }
                });

            migrationBuilder.InsertData(
                table: "StudentMark",
                columns: new[] { "Id", "Marks", "StudentId", "SubjectId" },
                values: new object[] { 1, 85, 1, 1 });

            migrationBuilder.InsertData(
                table: "StudentMark",
                columns: new[] { "Id", "Marks", "StudentId", "SubjectId" },
                values: new object[] { 2, 92, 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentMark",
                columns: new[] { "Id", "Marks", "StudentId", "SubjectId" },
                values: new object[] { 3, 78, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_StudentMark_StudentId",
                table: "StudentMark",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMark_SubjectId",
                table: "StudentMark",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentMark");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
