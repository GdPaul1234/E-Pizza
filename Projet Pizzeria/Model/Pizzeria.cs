using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Projet_Pizzeria.Model
{
    public class Pizzeria : IImportExportEffectif
    {
        public String Nom { get; set; }

        public virtual ICollection<Client> ListClient { get; set; } = new ObservableCollection<Client>();
        public virtual ICollection<Commis> ListCommis { get; set; } = new ObservableCollection<Commis>();
        public virtual ICollection<Livreur> ListLivreur { get; set; } = new ObservableCollection<Livreur>();

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