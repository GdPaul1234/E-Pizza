using Projet_Pizzeria.Model;
using System;
using System.Collections.Generic;

namespace Projet_Pizzeria.DAO
{
    public class AItemDataStore
    {
        public static List<Boisson> Boissons { get; set; }
        public static List<Pizza> Pizzas { get; set; }

        public AItemDataStore()
        {
            Boissons = new List<Boisson>
                {
                    new Boisson { Nom="Coca", Prix=3.5, Volume=0.33 },
                    new Boisson { Nom="Jus d'orange", Prix=5, Volume=0.5 },
                    new Boisson { Nom="Fanta", Prix=3, Volume=0.33 },
                    new Boisson { Nom="Cristaline", Prix=1.5, Volume=0.5 }
                };

            Pizzas = new List<Pizza>
            {
                new Pizza { Nom = "MARGHERITA", Prix = 12, Type = "sauce/fromage", Taille = "2 - Moyenne" },
                new Pizza { Nom = "VEGETARIANA", Prix = 16, Type = "vegetariennes", Taille = "2 - Moyenne" },
                new Pizza { Nom = "QUEEN TARTUFO", Prix = 20, Type = "toutes garnies", Taille = "2 - Moyenne" },
                new Pizza { Nom = "MARGHERITA", Prix = 10, Type = "sauce/fromage", Taille = "1 - Petite" },
                new Pizza { Nom = "VEGETARIANA", Prix = 14, Type = "vegetariennes", Taille = "1 - Petite" },
                new Pizza { Nom = "QUEEN TARTUFO", Prix = 18, Type = "toutes garnies", Taille = "1 - Petite" },
                new Pizza { Nom = "MARGHERITA", Prix = 14, Type = "sauce/fromage", Taille = "3 - Grande" },
                new Pizza { Nom = "VEGETARIANA", Prix = 18, Type = "vegetariennes", Taille = "3 - Grande" },
                new Pizza { Nom = "QUEEN TARTUFO", Prix = 22, Type = "toutes garnies", Taille = "3 - Grande" },
            };
        }

    }
}
