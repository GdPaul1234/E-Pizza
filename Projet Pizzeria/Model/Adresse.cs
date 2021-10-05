
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public class Adresse
    {
        public int AdresseId { get; set; }

        public string Rue { get; set; }
        public string Ville { get; set; }
        public string Cp { get; set; }
    }
}