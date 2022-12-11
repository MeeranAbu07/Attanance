using Microsoft.EntityFrameworkCore.Migrations;

namespace Attanance.Migrations
{
    public partial class MakInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MakCollages",
                columns: table => new
                {
                    CollageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Collage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakCollages", x => x.CollageId);
                });

            migrationBuilder.CreateTable(
                name: "MakParents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakParents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MakUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MakCollages");

            migrationBuilder.DropTable(
                name: "MakParents");

            migrationBuilder.DropTable(
                name: "MakUsers");
        }
    }
}
