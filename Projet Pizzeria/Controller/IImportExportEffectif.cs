namespace Projet_Pizzeria.Model
{
    public interface IImportExportEffectif
    {
        /// <summary>
        /// Import Client � partir d'un db SqLite
        /// </summary>
        /// <returns>True si succ�s, False sinon</returns>
        bool ImportClient();

        /// <summary>
        /// Export Client dans db client.db
        /// </summary>
        /// <returns>True si succ�s, False sinon</returns>
        bool ExportClient();

        /// <summary>
        /// Import Livreur � partir d'un db SqLite
        /// </summary>
        /// <returns>True si succ�s, False sinon</returns>
        bool ImportLivreur();

        /// <summary>
        /// Export Livreur dans db livreur.db
        /// </summary>
        /// <returns>True si succ�s, False sinon</returns>
        bool ExportLivreur();

        /// <summary>
        /// Import Livreur � partir d'un db SqLite
        /// </summary>
        /// <returns>True si succ�s, False sinon</returns>
        bool ImportCommis();

        /// <summary>
        /// Export Commis dans db commis.db
        /// </summary>
        /// <returns>True si succ�s, False sinon</returns>
        bool ExportCommis();
    }
}