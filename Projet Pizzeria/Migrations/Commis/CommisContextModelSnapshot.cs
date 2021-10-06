﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projet_Pizzeria.DAO;

namespace Projet_Pizzeria.Migrations.Commis
{
    [DbContext(typeof(CommisContext))]
    partial class CommisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19");

            modelBuilder.Entity("Projet_Pizzeria.Model.Commis", b =>
                {
                    b.Property<long>("NoCmmis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbDeCommandeGeree")
                        .HasColumnType("INTEGER");

                    b.HasKey("NoCmmis");

                    b.ToTable("Commis");
                });
#pragma warning restore 612, 618
        }
    }
}