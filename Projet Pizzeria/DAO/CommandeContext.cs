using Microsoft.EntityFrameworkCore;
using Projet_Pizzeria.Model;
using System;

namespace Projet_Pizzeria.DAO
{
    internal class CommandeContext : DbContext
    {
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Boisson> Boisons { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        public string DbPath { get; private set; }

        // https://docs.microsoft.com/fr-fr/ef/core/get-started/overview/first-app?tabs=visual-studio
        public CommandeContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var sep = System.IO.Path.DirectorySeparatorChar;
            DbPath = $"{path}{sep}Pizzeria{sep}commandes.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
            options.UseLazyLoadingProxies();
            base.OnConfiguring(options);
        }
    }
}