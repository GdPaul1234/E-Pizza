using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Projet_Pizzeria.Migrations.Commande
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    AdresseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rue = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true),
                    Cp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.AdresseId);
                });

            migrationBuilder.CreateTable(
                name: "Commis",
                columns: table => new
                {
                    NoCommis = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    NbDeCommandeGeree = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commis", x => x.NoCommis);
                });

            migrationBuilder.CreateTable(
                name: "Livreur",
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
                    table.PrimaryKey("PK_Livreur", x => x.NoLivreur);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    NoClient = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    NoTelephone = table.Column<string>(nullable: true),
                    DatePremiereCommande = table.Column<DateTime>(nullable: false),
                    MontantAchatCumule = table.Column<double>(nullable: false),
                    AdresseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.NoClient);
                    table.ForeignKey(
                        name: "FK_Client_Adresse_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresse",
                        principalColumn: "AdresseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    NumeroCommande = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateHeureCommande = table.Column<DateTime>(nullable: false),
                    EtatCommande = table.Column<string>(nullable: true),
                    MontantTotal = table.Column<double>(nullable: false),
                    EstEncaissee = table.Column<int>(nullable: false),
                    CommisNoCommis = table.Column<long>(nullable: true),
                    ClientNoClient = table.Column<long>(nullable: true),
                    LivreurNoLivreur = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.NumeroCommande);
                    table.ForeignKey(
                        name: "FK_Commandes_Client_ClientNoClient",
                        column: x => x.ClientNoClient,
                        principalTable: "Client",
                        principalColumn: "NoClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commandes_Commis_CommisNoCommis",
                        column: x => x.CommisNoCommis,
                        principalTable: "Commis",
                        principalColumn: "NoCommis",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commandes_Livreur_LivreurNoLivreur",
                        column: x => x.LivreurNoLivreur,
                        principalTable: "Livreur",
                        principalColumn: "NoLivreur",
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
                name: "IX_Client_AdresseId",
                table: "Client",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ClientNoClient",
                table: "Commandes",
                column: "ClientNoClient");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_CommisNoCommis",
                table: "Commandes",
                column: "CommisNoCommis");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_LivreurNoLivreur",
                table: "Commandes",
                column: "LivreurNoLivreur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AItem");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Commis");

            migrationBuilder.DropTable(
                name: "Livreur");

            migrationBuilder.DropTable(
                name: "Adresse");
        }
    }
}