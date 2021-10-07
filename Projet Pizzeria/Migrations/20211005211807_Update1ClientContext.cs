using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet_Pizzeria.Migrations
{
    public partial class Update1ClientContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MontantAchatCumule",
                table: "Clients",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontantAchatCumule",
                table: "Clients");
        }
    }
}