
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public class Pizza : AItem
    {

        public string Taille { get; set; };
        public string Type { get; set; };

        public string Nom
        {
            get
            {
                return base.Nom;
            }

            set
            {
                base.Nom = value;
            }
        };

        public double Prix
        {
            get
            {
                return base.Prix;
            }

            set
            {
                base.Prix = value;
            }
        };

    }
}
