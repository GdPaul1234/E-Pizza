using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Projet_Pizzeria.Model
{
    public class Commande
    {
        [Key]
        public long NumeroCommande { get; set; }

        public DateTime DateHeureCommande { get; set; }
        public string EtatCommande { get; set; }
        public double MontantTotal { get; private set; }

        public virtual Client Client { get; set; }
        public virtual Commis Commis { get; set; }

        public virtual ICollection<AItem> Items { get; set; } = new ObservableCollection<AItem>();

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