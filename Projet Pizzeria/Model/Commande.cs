
using Projet_Pizzeria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public class Commande
    {
        [Key]
        public long NumeroCommande { get; set; }

        public DateTime DateHeureCommande { get; set; }
        public string EtatCommande { get; set; }
        public double MontantTotal { get; private set; }

        public Client Client { get; set; }
        public Commis Commis { get; set; }

        public List<AItem> Items { get; set; }

        /// <summary>
        /// @param p
        /// </summary>
        public void AddItem(AItem p)
        {
            // TODO implement here
        }

        /// <summary>
        /// @param p
        /// </summary>
        public void DelItem(AItem p)
        {
            // TODO implement here
        }

        /// <summary>
        /// @return
        /// </summary>
        public List<AItem> GetCommandeItems()
        {
            // TODO implement here
            return null;
        }

    }
}
