
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public class Pizzeria : IImportExportEffectif
    {

        public String Nom { get; set; };
        public HashSet<Client> ListClient { get; set; };
        public HashSet<Commis> ListCommis { get; set; };
        public HashSet<Livreur> ListLivreur { get; set; };

    }
}
