
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

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