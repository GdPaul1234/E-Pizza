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

        public static List<Commande> GetCommandeBetweenTime(DateTime start, DateTime stop)
        {
            return pizzeriaDb.Commandes.Where(c => c.DateHeureCommande >= start && c.DateHeureCommande <= stop)
                .ToList();
        }

        public double GetAvgPrixCommande() => pizzeriaDb.Commandes.Average(c => c.MontantTotal);
        

        public static List<KeyValuePair<Client, double>> GetAvgPrixClient()
        {
            return pizzeriaDb.Commandes.GroupBy(c => c.Client,
                c => c.MontantTotal,
                (client, montants) => 
                    new KeyValuePair<Client, double>(client, montants.Average()))
                .ToList();
        }
       
    }
}