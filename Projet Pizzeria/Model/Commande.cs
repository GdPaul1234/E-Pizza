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
        public double MontantTotal { get; set; }
        public int EstEncaissee { get; set; } = 0;

        public virtual Commis Commis { get; set; }
        public virtual Client Client { get; set; }
        public virtual Livreur Livreur { get; set; }
       
      
        public virtual ICollection<AItem> Items { get; private set; } = new ObservableCollection<AItem>();

        /// <summary>
        /// @param p
        /// </summary>
        public void AddItem(AItem p)
        {
            Items.Add(p);
            MontantTotal += p.Prix;
        }

        /// <summary>
        /// @param p
        /// </summary>
        public void DelItem(AItem p)
        {
            if (Items.Remove(p)) MontantTotal -= p.Prix;
        }
    }
}