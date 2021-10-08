﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projet_Pizzeria.DAO;

namespace Projet_Pizzeria.Migrations
{
    [DbContext(typeof(PizzeriaContext))]
    [Migration("20211008193930_Update3.34PizzaContext")]
    partial class Update334PizzaContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19");

            modelBuilder.Entity("Projet_Pizzeria.Model.AItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CommandeNumeroCommande")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<double>("Prix")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CommandeNumeroCommande");

                    b.ToTable("AItem");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AItem");
                });

            modelBuilder.Entity("Projet_Pizzeria.Model.Adresse", b =>
                {
                    b.Property<int>("AdresseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rue")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ville")
                        .HasColumnType("TEXT");

                    b.HasKey("AdresseId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Projet_Pizzeria.Model.Client", b =>
                {
                    b.Property<long>("NoClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AdresseId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DatePremiereCommande")
                        .HasColumnType("TEXT");

                    b.Property<double>("MontantAchatCumule")
                        .HasColumnType("REAL");

                    b.Property<string>("NoTelephone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.HasKey("NoClient");

                    b.HasIndex("AdresseId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Projet_Pizzeria.Model.Commande", b =>
                {
                    b.Property<long>("NumeroCommande")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ClientNoClient")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateHeureCommande")
                        .HasColumnType("TEXT");

                    b.Property<int>("EstEncaissee")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EtatCommande")
                        .HasColumnType("TEXT");

                    b.Property<long?>("LivreurNoLivreur")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MontantTotal")
                        .HasColumnType("REAL");

                    b.HasKey("NumeroCommande");

                    b.HasIndex("ClientNoClient");

                    b.HasIndex("LivreurNoLivreur");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("Projet_Pizzeria.Model.Commis", b =>
                {
                    b.Property<long>("NoCmmis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbDeCommandeGeree")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.HasKey("NoCmmis");

                    b.ToTable("Commis");
                });

            modelBuilder.Entity("Projet_Pizzeria.Model.Livreur", b =>
                {
                    b.Property<long>("NoLivreur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbLivraisonEffectue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.HasKey("NoLivreur");

                    b.ToTable("Livreurs");
                });

            modelBuilder.Entity("Projet_Pizzeria.Model.Boisson", b =>
                {
                    b.HasBaseType("Projet_Pizzeria.Model.AItem");

                    b.Property<double>("Volume")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("Boisson");
                });

            modelBuilder.Entity("Projet_Pizzeria.Model.Pizza", b =>
                {
                    b.HasBaseType("Projet_Pizzeria.Model.AItem");

                    b.Property<string>("Taille")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Pizza");
                });

            modelBuilder.Entity("Projet_Pizzeria.Model.AItem", b =>
                {
                    b.HasOne("Projet_Pizzeria.Model.Commande", null)
                        .WithMany("Items")
                        .HasForeignKey("CommandeNumeroCommande");
                });

            modelBuilder.Entity("Projet_Pizzeria.Model.Client", b =>
                {
                    b.HasOne("Projet_Pizzeria.Model.Adresse", "Adresse")
                        .WithMany()
                        .HasForeignKey("AdresseId");
                });

            modelBuilder.Entity("Projet_Pizzeria.Model.Commande", b =>
                {
                    b.HasOne("Projet_Pizzeria.Model.Client", "Client")
                        .WithMany("Commandes")
                        .HasForeignKey("ClientNoClient");

                    b.HasOne("Projet_Pizzeria.Model.Livreur", "Livreur")
                        .WithMany()
                        .HasForeignKey("LivreurNoLivreur");
                });
#pragma warning restore 612, 618
        }
    }
}