using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attanance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBasics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Doj = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBasics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "attanances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserBasicDetailsId = table.Column<int>(type: "int", nullable: false),
                    Attanance = table.Column<bool>(type: "bit", nullable: false),
                    LeaveReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttananceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attanances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attanances_UserBasics_UserBasicDetailsId",
                        column: x => x.UserBasicDetailsId,
                        principalTable: "UserBasics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attanances_UserBasicDetailsId",
                table: "attanances",
                column: "UserBasicDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attanances");

            migrationBuilder.DropTable(
                name: "UserBasics");
        }
    }
}
