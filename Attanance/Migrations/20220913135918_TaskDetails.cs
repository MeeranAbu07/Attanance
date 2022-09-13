using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attanance.Migrations
{
    public partial class TaskDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserBasicDetailsId = table.Column<int>(type: "int", nullable: false),
                    TaskDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskCompleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDetails_UserBasics_UserBasicDetailsId",
                        column: x => x.UserBasicDetailsId,
                        principalTable: "UserBasics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDetails_UserBasicDetailsId",
                table: "TaskDetails",
                column: "UserBasicDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDetails");
        }
    }
}
