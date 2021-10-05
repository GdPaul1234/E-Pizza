
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public class Livreur
    {
        [Key]
        public long NoLivreur { get; set; }

        public int NbLivraisonEffectue { get; set; }


        public void LivrerCommande()
        {
            // TODO implement here
        }

    }
}
