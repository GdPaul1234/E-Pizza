
using Projet_Pizzeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Controller
{
    public class ModuleClient : IImportExportEffectif, IManageEffectif
    {

        public ModuleClient()
        {
        }

        public long AddClient(Client c)
        {
            throw new NotImplementedException();
        }

        public void DelClient(long noClient)
        {
            throw new NotImplementedException();
        }

        public void EditClient(long noClient)
        {
            throw new NotImplementedException();
        }

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

        /// <summary>
        /// @param orderer Orderer 
        /// @return
        /// </summary>
        public List<Client> GetClientsOrderBy()
        {
            // TODO implement here
            return null;
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
