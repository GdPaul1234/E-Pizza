using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

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
        public double MontantAchatCumule { get; set; }

        public virtual ICollection<Commande> Commandes { get; private set; } = new ObservableCollection<Commande>();

        public virtual Adresse Adresse { get; set; }

        public void AjouterNouvelleCommande(Commande commande)
        {
            Commandes.Add(commande);
        }

        public override string ToString()
        {
            return $"{Nom} {Prenom} ({NoTelephone})";
        }
    }
}