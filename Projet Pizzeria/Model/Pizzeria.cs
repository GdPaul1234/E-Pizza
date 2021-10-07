using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Projet_Pizzeria.Model
{
    public class Pizzeria
    {
        public virtual ICollection<Client> ListClient { get; set; } = new ObservableCollection<Client>();
        public virtual ICollection<Commis> ListCommis { get; set; } = new ObservableCollection<Commis>();
        public virtual ICollection<Livreur> ListLivreur { get; set; } = new ObservableCollection<Livreur>();
        public String Nom { get; set; }
    }
}