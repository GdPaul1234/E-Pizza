
using System;
using System.Collections.Generic;
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
        public DateTime DatePremiereCommande { get; set; }

        [NotMapped]
        public List<Commande> Commandes { get; private set; } = new List<Commande>();

        public Adresse Adresse { get; set; }

        /// <summary>
        /// @return
        /// </summary>
        public Commande CreerNouvelleCommande()
        {
            // TODO implement here
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
