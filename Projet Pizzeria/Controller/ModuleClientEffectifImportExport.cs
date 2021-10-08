using Microsoft.EntityFrameworkCore;
using Projet_Pizzeria.DAO;
using Projet_Pizzeria.Model;
using Projet_Pizzeria.Model.Comparer;
using System;
using System.Collections;
using System.Linq;

namespace Projet_Pizzeria.Controller
{
    public partial class ModuleClientEffectif : IImportExportEffectif
    {
        #region IImportExportEffectif Implementation

        #region Import Export Client
        public void ExportClient()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _clientContext = new ClientContext())
            {
                // Clear the Client DB
                _clientContext.Database.EnsureDeleted();
                _clientContext.Database.EnsureCreated();
                {
                    _clientContext.Clients.AddRange(_pizzeriaContext.Clients);
                    _clientContext.Adresses.AddRange(_pizzeriaContext.Adresses);
                    _clientContext.SaveChanges();
                }
            }
        }

        public void ImportClient()
        {
            var _pizzeriaContext = new PizzeriaContext();
            using (var _clientContext = new ClientContext())
            {
                _clientContext.Database.EnsureCreated();
                {
                    // TODO FIX ME
                    var listClientImport = _clientContext.Clients.ToList()
                        .Except(_pizzeriaContext.Clients.ToList(), new ClientComparer());
                    foreach (Client client in listClientImport)
                    {
                        _pizzeriaContext.Add(new Client
                        {
                            Nom = client.Nom,
                            Prenom = client.Prenom,
                            NoTelephone = client.NoTelephone,
                            DatePremiereCommande = client.DatePremiereCommande,
                            MontantAchatCumule = client.MontantAchatCumule,
                            Adresse = new Adresse
                            {
                                Rue = client.Adresse.Rue,
                                Ville = client.Adresse.Ville,
                                Cp = client.Adresse.Cp
                            }
                        });
                    }

                    _pizzeriaContext.SaveChanges();
                }
            }
        }
        #endregion // Import Export Client

        #region Import Export Commis
        public void ExportCommis()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _commisContext = new CommisContext())
            {
                // Clear the Client DB
                _commisContext.Database.EnsureDeleted();
                _commisContext.Database.EnsureCreated();
                {
                    _commisContext.Commis.AddRange(_pizzeriaContext.Commis);
                    _commisContext.SaveChanges();
                }
            }
        }

        public void ImportCommis()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _commisContext = new CommisContext())
            {
                _commisContext.Database.EnsureCreated();
                {
                    _pizzeriaContext.Commis.AddRange(_commisContext.Commis);
                    _pizzeriaContext.SaveChanges();
                }
            }
        }

        #endregion // Import Export Commis

        #region Import Export Livreur

        public void ExportLivreur()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _livreurContext = new LivreurContext())
            {
                // Clear the Client DB
                _livreurContext.Database.EnsureDeleted();
                _livreurContext.Database.EnsureCreated();
                {
                    _livreurContext.Livreurs.AddRange(_pizzeriaContext.Livreurs);
                    _livreurContext.SaveChanges();
                }
            }
        }

        public void ImportLivreur()
        {
            using (var _pizzeriaContext = new PizzeriaContext())
            using (var _livreurContext = new LivreurContext())
            {
                _livreurContext.Database.EnsureCreated();
                {
                    _pizzeriaContext.Livreurs.AddRange(_livreurContext.Livreurs);
                    _pizzeriaContext.SaveChanges();
                }
            }
        }

        #endregion // Import Export Livreur

        #endregion // IImportExportEffectif Implementation
    }
}
