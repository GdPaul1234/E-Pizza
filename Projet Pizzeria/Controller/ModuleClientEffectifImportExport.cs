using Projet_Pizzeria.DAO;
using Projet_Pizzeria.Model;

namespace Projet_Pizzeria.Controller
{
    public partial class ModuleClientEffectif : IImportExportEffectif
    {
        #region IImportExportEffectif Implementation

        #region Import Export Client
        public bool ExportClient()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _clientContext = new ClientContext())
            {
                // Clear the Client DB
                if (_clientContext.Database.EnsureDeleted()
                    && _clientContext.Database.EnsureCreated())
                {
                    _clientContext.Clients.AddRange(_pizzeriaContext.Clients);
                    _clientContext.Adresses.AddRange(_pizzeriaContext.Adresses);
                    _clientContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool ImportClient()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _clientContext = new ClientContext())
            {
                if (_clientContext.Database.EnsureCreated())
                {
                    _pizzeriaContext.Clients.AddRange(_clientContext.Clients);
                    _pizzeriaContext.Adresses.AddRange(_clientContext.Adresses);
                    _pizzeriaContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        #endregion // Import Export Client

        #region Import Export Commis
        public bool ExportCommis()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _commisContext = new CommisContext())
            {
                // Clear the Client DB
                if (_commisContext.Database.EnsureDeleted()
                    && _commisContext.Database.EnsureCreated())
                {
                    _commisContext.Commis.AddRange(_pizzeriaContext.Commis);
                    _commisContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool ImportCommis()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _commisContext = new CommisContext())
            {
                if (_commisContext.Database.EnsureCreated())
                {
                    _pizzeriaContext.Commis.AddRange(_commisContext.Commis);
                    _pizzeriaContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        #endregion // Import Export Commis

        #region Import Export Livreur

        public bool ExportLivreur()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _livreurContext = new LivreurContext())
            {
                // Clear the Client DB
                if (_livreurContext.Database.EnsureDeleted()
                    && _livreurContext.Database.EnsureCreated())
                {
                    _livreurContext.Livreurs.AddRange(_pizzeriaContext.Livreurs);
                    _livreurContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool ImportLivreur()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _livreurContext = new LivreurContext())
            {
                if (_livreurContext.Database.EnsureCreated())
                {
                    _pizzeriaContext.Livreurs.AddRange(_livreurContext.Livreurs);
                    _pizzeriaContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        #endregion // Import Export Livreur

        #endregion // IImportExportEffectif Implementation
    }
}
