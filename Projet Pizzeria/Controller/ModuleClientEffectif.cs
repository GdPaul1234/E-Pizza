using Microsoft.EntityFrameworkCore;
using Projet_Pizzeria.DAO;
using Projet_Pizzeria.Model;
using System.Linq;

namespace Projet_Pizzeria.Controller
{
    public partial class ModuleClientEffectif : IManageEffectif, IClientOrderer
    {
        private static PizzeriaContext pizzeriaDb = null;
        public IQueryable<Client> ClientResultSet { get; set; }

        public ModuleClientEffectif()
        {
            if (pizzeriaDb == null)
                pizzeriaDb = new PizzeriaContext();

            ClientResultSet = pizzeriaDb.Clients;
            RefreshResultSet();
        }

        ~ModuleClientEffectif()  // finalizer
        {
            pizzeriaDb.Dispose();
        }

        private void RefreshResultSet()
        {
            // Refresh
            ClientResultSet.Load();
        }

        #region CRUD Client

        public long AddClient(Client c)
        {
            pizzeriaDb.Clients.Add(c);
            pizzeriaDb.SaveChanges();
            RefreshResultSet();
            return c.NoClient;
        }

        public void DelClient(long noClient)
        {
            Client deletingClient = pizzeriaDb.Clients.FirstOrDefault(c => c.NoClient == noClient);
            if (deletingClient != null)
            {
                pizzeriaDb.Clients.Remove(deletingClient);
                pizzeriaDb.SaveChanges();
                RefreshResultSet();
            }
        }

        public void EditClient(long noClient, Client c)
        {
            Client editingClient = pizzeriaDb.Clients.FirstOrDefault(client => client.NoClient == noClient);
            if (editingClient != null)
            {
                editingClient.Nom = c.Nom;
                editingClient.Prenom = c.Prenom;
                editingClient.NoTelephone = c.NoTelephone;
                editingClient.Adresse = c.Adresse;
                editingClient.NoClient = c.NoClient;
                pizzeriaDb.SaveChanges();
                RefreshResultSet();
            }
        }

        #endregion CRUD Client

        #region Interface IClientOrderer

        public IClientOrderer OrderByAlphaOrder(int direction)
        {
            if (direction > 0)
                ClientResultSet = ClientResultSet.OrderBy(c => c.Nom);
            else if (direction < 0)
                ClientResultSet = ClientResultSet.OrderByDescending(c => c.Nom);

            return this;
        }

        public IClientOrderer OrderByAchatCumule(int direction)
        {
            if (direction > 0)
                ClientResultSet = ClientResultSet.OrderBy(c => c.MontantAchatCumule);
            else if (direction < 0)
                ClientResultSet = ClientResultSet.OrderByDescending(c => c.MontantAchatCumule);
            return this;
        }

        public IClientOrderer FilterByCity(string city, DelReApplyFilter callback)
        {
            ResetFilter();

            ClientResultSet = ClientResultSet.Where(c => c.Adresse.Ville.Contains(city))
                .OrderBy(c => c.Adresse.Ville);

            // L'UI doit ensuite réappliquer les filtres enregistrées
            if (callback != null) callback();

            return this;
        }

        public IQueryable<Client> Collect()
        {
            RefreshResultSet();
            return ClientResultSet;
        }

        public void ResetFilter()
        {
            ClientResultSet = pizzeriaDb.Clients;
            RefreshResultSet();
        }

        #endregion Interface IClientOrderer
    }
}