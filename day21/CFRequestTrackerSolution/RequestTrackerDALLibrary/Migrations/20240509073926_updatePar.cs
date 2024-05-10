using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerDALLibrary.Migrations
{
    public partial class updatePar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_ClosedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RaisedBy",
                table: "Requests");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_ClosedBy",
                table: "Requests",
                column: "ClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RaisedBy",
                table: "Requests",
                column: "RaisedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_ClosedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RaisedBy",
                table: "Requests");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_ClosedBy",
                table: "Requests",
                column: "ClosedBy",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RaisedBy",
                table: "Requests",
                column: "RaisedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
