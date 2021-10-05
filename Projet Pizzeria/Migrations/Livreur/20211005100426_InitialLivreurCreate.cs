using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet_Pizzeria.Migrations.Livreur
{
    public partial class InitialLivreurCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livreurs",
                columns: table => new
                {
                    NoLivreur = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NbLivraisonEffectue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livreurs", x => x.NoLivreur);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livreurs");
        }
    }
}
