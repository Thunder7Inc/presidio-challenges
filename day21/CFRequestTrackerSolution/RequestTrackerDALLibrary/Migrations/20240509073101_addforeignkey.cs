using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerDALLibrary.Migrations
{
    public partial class addforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClosedBy",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClosedBy",
                table: "Requests",
                column: "ClosedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_ClosedBy",
                table: "Requests",
                column: "ClosedBy",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_ClosedBy",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ClosedBy",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ClosedBy",
                table: "Requests");
        }
    }
}
