using Projet_Pizzeria.Model;
using System;
using System.Collections.Generic;

namespace Projet_Pizzeria.Controller
{
    public class ModuleStatistiques
    {
        public ModuleStatistiques()
        {
        }

        public void GroupByCommisNbCommandesGerees()
        {
            // TODO implement here
        }

        public void GroupByLivreurNbLivraisonsEffectues()
        {
            // TODO implement here
        }

        /// <summary>
        /// @param start
        /// @param stop
        /// @return
        /// </summary>
        public List<Commande> GetCommandeBetweenTime(DateTime start, DateTime stop)
        {
            // TODO implement here
            return null;
        }

        /// <summary>
        /// @return
        /// </summary>
        public double GetAvgPrixCommande()
        {
            // TODO implement here
            return 0.0D;
        }

        /// <summary>
        /// @return
        /// </summary>
        public Tuple<double> GetAvgPrixClient()
        {
            // TODO implement here
            return null;
        }
    }
}