
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public class Commande
    {

        public long NumeroCommande { get; set };
        public Date DateHeureCommande { get; set };
        public string EtatCommande { get; set };
        public double MontantTotal { get; private set };


        private Commis Commis;

        private HashSet<AItem> Items;

        /// <summary>
        /// @param p
        /// </summary>
        public void Add(IProduit p)
        {
            // TODO implement here
        }

        /// <summary>
        /// @param p
        /// </summary>
        public void Del(IProduit p)
        {
            // TODO implement here
        }

        /// <summary>
        /// @return
        /// </summary>
        public List<IProduit> Get()
        {
            // TODO implement here
            return null;
        }

    }
}
