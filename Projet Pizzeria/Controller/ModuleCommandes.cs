using Microsoft.EntityFrameworkCore;
using Projet_Pizzeria.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet_Pizzeria.Model.Controller
{
    public class ModuleCommandes
    {
        private static PizzeriaContext pizzeriaDb = null;
        public IQueryable<Commande> CommandeResultSet { get; set; }

        public ModuleCommandes()
        {
            if (pizzeriaDb == null)
                pizzeriaDb = new PizzeriaContext();

            CommandeResultSet = pizzeriaDb.Commandes;
            RefreshResultSet();
        }

        private void RefreshResultSet()
        {
            // Refresh
            CommandeResultSet.Load();
        }

        #region CRU_ Commandes

        public void CreateNouvelleCommande(Client c, List<AItem> items)
        {
            // assigner un commis et un livreur random
            Random rand = new Random();
            int toSkipCommis = rand.Next(0, pizzeriaDb.Commis.Count());
            int toSkipLivreur = rand.Next(0, pizzeriaDb.Livreurs.Count());

            Commis selectedCommis = pizzeriaDb.Commis.Skip(toSkipCommis).Take(1).First();
            Livreur selectedLivreur = pizzeriaDb.Livreurs.Skip(toSkipLivreur).Take(1).First();

            // création commande
            Commande commande = new Commande
            {
                Client = c,
                Commis = selectedCommis,
                Livreur = selectedLivreur,
                DateHeureCommande = new DateTime(),
                EstEncaissee = 0,
                Items = items,
                MontantTotal = items.Sum(i => i.Prix)
            };

            // c doit être managé par Ef Core
            c.AjouterNouvelleCommande(commande);
            c.MontantAchatCumule += commande.MontantTotal;
            pizzeriaDb.Attach(c);
            pizzeriaDb.SaveChanges();
        }

        public Commande EditCommande(Client c)
        {
            // TODO implement here
            return null;
        }

        #endregion // CRU_ Commandes


        /// <summary>
        /// @param noCommande
        /// @return
        /// </summary>
        public double CalculerPrixCommande(long noCommande)
        {
            // TODO implement here
            return 0.0D;
        }

        /// <summary>
        /// @param long nbCommande
        /// @return
        /// </summary>
        public Commande GetCommandeByNumber(long nbCommande)
        {
            // TODO implement here
            return null;
        }

        public void ImportCommande()
        {
            // TODO implement here
        }
    }
}