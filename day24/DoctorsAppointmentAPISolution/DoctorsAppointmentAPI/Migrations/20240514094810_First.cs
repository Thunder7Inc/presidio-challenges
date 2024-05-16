using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorsAppointmentAPI.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experiance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DoctorName", "Experiance", "Specialization", "phonenumber" },
                values: new object[] { 1, "Dr. Smith", 10, "Cardiology", "123-456-7890" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DoctorName", "Experiance", "Specialization", "phonenumber" },
                values: new object[] { 2, "Dr. Johnson", 8, "Pediatrics", "987-654-3210" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
