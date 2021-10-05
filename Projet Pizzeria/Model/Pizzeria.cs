
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public class Pizzeria : IImportExportEffectif
    {

        public String Nom { get; set; }

        public List<Client> ListClient { get; set; } = new List<Client>();
        public List<Commis> ListCommis { get; set; } = new List<Commis>();
        public List<Livreur> ListLivreur { get; set; } = new List<Livreur>();

        public void ExportClient()
        {
            throw new NotImplementedException();
        }

        public void ExportCommis()
        {
            throw new NotImplementedException();
        }

        public void ExportLivreur()
        {
            throw new NotImplementedException();
        }

        public void ImportClient()
        {
            throw new NotImplementedException();
        }

        public void ImportCommis()
        {
            throw new NotImplementedException();
        }

        public void ImportLivreur()
        {
            throw new NotImplementedException();
        }
    }
}
