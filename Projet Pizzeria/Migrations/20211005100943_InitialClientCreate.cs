using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Projet_Pizzeria.Migrations
{
    public partial class InitialClientCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
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
                    table.PrimaryKey("PK_Adresses", x => x.AdresseId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    NoClient = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    NoTelephone = table.Column<string>(nullable: true),
                    DatePremiereCommande = table.Column<DateTime>(nullable: false),
                    AdresseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.NoClient);
                    table.ForeignKey(
                        name: "FK_Clients_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AdresseId",
                table: "Clients",
                column: "AdresseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}