using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Projet_Pizzeria.Migrations
{
    public partial class Update2ClientContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    NumeroCommande = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateHeureCommande = table.Column<DateTime>(nullable: false),
                    EtatCommande = table.Column<string>(nullable: true),
                    MontantTotal = table.Column<double>(nullable: false),
                    ClientNoClient = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.NumeroCommande);
                    table.ForeignKey(
                        name: "FK_Commandes_Clients_ClientNoClient",
                        column: x => x.ClientNoClient,
                        principalTable: "Clients",
                        principalColumn: "NoClient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Prix = table.Column<double>(nullable: false),
                    CommandeNumeroCommande = table.Column<long>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Volume = table.Column<double>(nullable: true),
                    Taille = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AItem_Commandes_CommandeNumeroCommande",
                        column: x => x.CommandeNumeroCommande,
                        principalTable: "Commandes",
                        principalColumn: "NumeroCommande",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AItem_CommandeNumeroCommande",
                table: "AItem",
                column: "CommandeNumeroCommande");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ClientNoClient",
                table: "Commandes",
                column: "ClientNoClient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AItem");

            migrationBuilder.DropTable(
                name: "Commandes");
        }
    }
}
