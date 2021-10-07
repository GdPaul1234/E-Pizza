using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projet_Pizzeria.Model
{
    public class Commis : DbContext
    {
        [Key]
        public long NoCmmis { get; set; }

        public int NbDeCommandeGeree { get; private set; }

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