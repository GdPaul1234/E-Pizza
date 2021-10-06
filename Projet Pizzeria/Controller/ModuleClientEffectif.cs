
using Projet_Pizzeria.DAO;
using Projet_Pizzeria.Model;
using System.Collections.Generic;
using System.Linq;

namespace Projet_Pizzeria.Controller
{
    public class ModuleClientEffectif : IManageEffectif, IClientOrderer
    {
        private static PizzeriaContext pizzeriaDb = null;
        public List<Client> ClientResultSet { get; set; }

        public ModuleClientEffectif()
        {
            if (pizzeriaDb == null)
                pizzeriaDb = new PizzeriaContext();

            ClientResultSet = pizzeriaDb.Clients.ToList();
        }

        ~ModuleClientEffectif()  // finalizer
        {
            pizzeriaDb.Dispose();
        }

        private void RefreshResultSet()
        {
            // Refresh
            ClientResultSet.Clear();
            ClientResultSet.AddRange(pizzeriaDb.Clients.ToList());
        }

        /**
         * CRUD Client
         **/

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

        /**
         * Orderer Client
         **/

        public IClientOrderer OrderByAlphaOrder(int direction)
        {
            if (direction > 0)
                ClientResultSet = ClientResultSet.OrderBy(c => c.Nom).ToList();
            else if (direction < 0)
                ClientResultSet = ClientResultSet.OrderByDescending(c => c.Nom).ToList();

            return this;
        }

        public IClientOrderer OrderByAchatCumule()
        {
            ClientResultSet = ClientResultSet.OrderByDescending(c => c.MontantAchatCumule).ToList();
            return this;
        }

        public IClientOrderer FilterByCity(string city)
        {
            ClientResultSet = ClientResultSet.Where(c => c.Adresse.Ville == city)
                .OrderBy(c => c.Adresse.Ville).ToList();
            return this;
        }

        public List<Client> Collect()
        {
            return ClientResultSet;
        }
    }
}
