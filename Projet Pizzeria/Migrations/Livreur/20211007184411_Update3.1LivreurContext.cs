using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet_Pizzeria.Migrations.Livreur
{
    public partial class Update31LivreurContext : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Livreurs");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "Livreurs");
        }
    }
}
