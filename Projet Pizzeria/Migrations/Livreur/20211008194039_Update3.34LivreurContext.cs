using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet_Pizzeria.Migrations.Livreur
{
    public partial class Update334LivreurContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livreurs",
                columns: table => new
                {
                    NoLivreur = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
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
