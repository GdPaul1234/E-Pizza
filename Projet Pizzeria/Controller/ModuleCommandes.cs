using Microsoft.EntityFrameworkCore;
using Projet_Pizzeria.Controller;
using Projet_Pizzeria.DAO;
using System;
using System.Linq;

namespace Projet_Pizzeria.Model.Controller
{
    public class ModuleCommandes : ICommandeOrderer
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

        public Client FindClientByPhone(string noTelephone)
        {
            return pizzeriaDb.Clients.FirstOrDefault(c => c.NoTelephone == noTelephone);
        }

        public void CreateNouvelleCommande(Client c, Commande commande)
        {
            // assigner un commis et un livreur random
            Random rand = new Random();
            int toSkipCommis = rand.Next(0, pizzeriaDb.Commis.Count());
            int toSkipLivreur = rand.Next(0, pizzeriaDb.Livreurs.Count());

            Console.Write(toSkipCommis);

            Commis selectedCommis = pizzeriaDb.Commis.Skip(toSkipCommis).Take(1).First();
            Livreur selectedLivreur = pizzeriaDb.Livreurs.Skip(toSkipLivreur).Take(1).First();

            // finir remplissage commande
            commande.Client = c;
            commande.Commis = selectedCommis;
            commande.Livreur = selectedLivreur;
            commande.DateHeureCommande = DateTime.Now;
            commande.EtatCommande = "En préparation";
            commande.EstEncaissee = 0;

            // gratifier le comis pour le service rendu à la pizzeria
            selectedCommis.NbDeCommandeGeree++;

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

        public void ImportCommande()
        {
            // TODO implement here
        }

        #region ICommandeOrderer implementation
        public ICommandeOrderer FilterByEtat(string etat)
        {
            ResetFilter();
            CommandeResultSet = CommandeResultSet.Where(c => c.EtatCommande == etat)
                .OrderByDescending(c => c.DateHeureCommande);
            return this;
        }

        public ICommandeOrderer SearchByNumber(long numeroCommande)
        {
            CommandeResultSet = CommandeResultSet.Where(c => c.NumeroCommande == numeroCommande)
                .OrderByDescending(c => c.DateHeureCommande);
            return this;
        }

        public IQueryable<Commande> Collect()
        {
            RefreshResultSet();
            return CommandeResultSet;
        }

        public void ResetFilter()
        {
            CommandeResultSet = pizzeriaDb.Commandes;
            RefreshResultSet();
        }
        #endregion // ICommandeOrderer implementation
    }
}