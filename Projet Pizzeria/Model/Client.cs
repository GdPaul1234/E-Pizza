
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public class Client
    {
        [Key]
        public long NoClient { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NoTelephone { get; set; }
        public DateTime DatePremiereCommande { get; private set; }
        public double MontantAchatCumule { get; private set; }

        public virtual ICollection<Commande> Commandes { get; private set; } = new ObservableCollection<Commande>();

        public virtual Adresse Adresse { get; set; }

        /// <summary>
        /// @return
        /// </summary>
        public Commande CreerNouvelleCommande()
        {
            return null;
        }

        /// <summary>
        /// @return
        /// </summary>
        public int GetNbCommandes()
        {
            // TODO implement here
            return 0;
        }

    }
}
