
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Pizzeria.Model
{
    public interface IImportExportEffectif
    {

        void ImportClient();

        void ExportClient();

        void ImportLivreur();

        void ExportLivreur();

        void ImportCommis();

        void ExportCommis();

    }

}