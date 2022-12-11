using Microsoft.EntityFrameworkCore.Migrations;

namespace Attanance.Migrations
{
    public partial class ExcelInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "excelAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_excelAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExcelHomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentOrOwn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelHomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExcelUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "excelAddresses");

            migrationBuilder.DropTable(
                name: "ExcelHomes");

            migrationBuilder.DropTable(
                name: "ExcelUsers");
        }
    }
}
