using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet_Pizzeria.Migrations.Commis
{
    public partial class InitialCommisCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commis",
                columns: table => new
                {
                    NoCmmis = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NbDeCommandeGeree = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commis", x => x.NoCmmis);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commis");
        }
    }
}