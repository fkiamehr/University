using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class miginitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentLevels",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelTitle = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLevels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_StudentLevels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "StudentLevels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_LevelId",
                table: "Students",
                column: "LevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudentLevels");
        }
    }
}
