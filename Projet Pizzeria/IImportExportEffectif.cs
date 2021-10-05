
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public interface IImportExportEffectif
    {

        public void ImportClient();

        public void ExportClient();

        public void ImportLivreur();

        public void ExportLivreur();

        public void ImportCommis();

        public void ExportCommis();

    }

}