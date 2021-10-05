
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public class Boisson : AItem
    {

        public double Volume { get; set; };

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
