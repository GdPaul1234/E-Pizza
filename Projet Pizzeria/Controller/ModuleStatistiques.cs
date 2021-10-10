using Microsoft.EntityFrameworkCore;
using Projet_Pizzeria.DAO;
using Projet_Pizzeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet_Pizzeria.Controller
{
    public class ModuleStatistiques
    {
        private static PizzeriaContext pizzeriaDb = null;

        public ModuleStatistiques()
        {
            if (pizzeriaDb == null)
                pizzeriaDb = new PizzeriaContext();
        }

        public List<Commande> GetCommandeBetweenTime(DateTime start, DateTime stop)
        {
            return pizzeriaDb.Commandes.Where(c => c.DateHeureCommande >= start && c.DateHeureCommande <= stop)
                .ToList();
        }

        public double GetAvgPrixCommande()
        {
            pizzeriaDb.Commandes.Load();
            return pizzeriaDb.Commandes.Average(c => c.MontantTotal);
        }

        public double GetAvgPrixClient()
        {
            pizzeriaDb.Clients.Load();
            return pizzeriaDb.Clients.Average(c => c.MontantAchatCumule);
        }
    }
}