using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactApp.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prijmeni",
                table: "User",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Jmeno",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Heslo",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "TerminVyprseniKontraktu",
                table: "Employee",
                newName: "ExpiryDateOfContract");

            migrationBuilder.RenameColumn(
                name: "Prijmeni",
                table: "Employee",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "PracovniPozice",
                table: "Employee",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "Jmeno",
                table: "Employee",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IdZamestnance",
                table: "Employee",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "User",
                newName: "Prijmeni");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "Heslo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "Jmeno");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Employee",
                newName: "Prijmeni");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Employee",
                newName: "PracovniPozice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employee",
                newName: "Jmeno");

            migrationBuilder.RenameColumn(
                name: "ExpiryDateOfContract",
                table: "Employee",
                newName: "TerminVyprseniKontraktu");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employee",
                newName: "IdZamestnance");
        }
    }
}
