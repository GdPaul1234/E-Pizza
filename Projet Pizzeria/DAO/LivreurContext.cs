using Microsoft.EntityFrameworkCore;
using Projet_Pizzeria.Model;
using System;

namespace Projet_Pizzeria.DAO
{
    internal class LivreurContext : DbContext
    {
        public DbSet<Livreur> Livreurs { get; set; }

        public string DbPath { get; private set; }

        // https://docs.microsoft.com/fr-fr/ef/core/get-started/overview/first-app?tabs=visual-studio
        public LivreurContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var sep = System.IO.Path.DirectorySeparatorChar;
            DbPath = $"{path}{sep}Pizzeria{sep}livreurs.db";
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