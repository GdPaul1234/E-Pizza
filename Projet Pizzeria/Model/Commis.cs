using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projet_Pizzeria.Model
{
    public class Commis
    {
        [Key]
        public long NoCommis { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public int NbDeCommandeGeree { get; set; }

        public void ConnaitreEtatCommande()
        {
            // TODO implement here
        }

        public void EncaisserLivraison()
        {
            // TODO implement here
        }

        public void EnvoyerCommande()
        {
            // TODO implement here
        }
    }
}