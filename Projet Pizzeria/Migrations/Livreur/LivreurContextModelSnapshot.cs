﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projet_Pizzeria.DAO;

namespace Projet_Pizzeria.Migrations.Livreur
{
    [DbContext(typeof(LivreurContext))]
    partial class LivreurContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19");

            modelBuilder.Entity("Projet_Pizzeria.Model.Livreur", b =>
                {
                    b.Property<long>("NoLivreur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbLivraisonEffectue")
                        .HasColumnType("INTEGER");

                    b.HasKey("NoLivreur");

                    b.ToTable("Livreurs");
                });
#pragma warning restore 612, 618
        }
    }
}
