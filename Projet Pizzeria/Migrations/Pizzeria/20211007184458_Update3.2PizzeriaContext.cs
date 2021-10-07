using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet_Pizzeria.Migrations.Pizzeria
{
    public partial class Update32PizzeriaContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Livreurs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "Livreurs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Commis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "Commis",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Livreurs");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "Livreurs");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Commis");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "Commis");
        }
    }
}
