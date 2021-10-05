
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public abstract class AItem
    {
        public int Id { get; set; }

        public string Nom { get; set; }
        public double Prix { get; set; }


    }
}
