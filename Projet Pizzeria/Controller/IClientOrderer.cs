using Projet_Pizzeria.Model;
using System.Linq;

namespace Projet_Pizzeria.Controller
{
    public delegate void DelReApplyFilter();

    public interface IClientOrderer
    {
        /// <summary>
        /// Trier par ordre alphabéthique
        /// </summary>
        /// <param name="direction">direction (> 0 : ascendant, < 0 : descendant)</param>
        ///<returns></returns>
        IClientOrderer OrderByAlphaOrder(int direction);

        /// <summary>
        /// Trier par ordre achats cumulés
        /// </summary>
        /// <param name="direction">direction (> 0 : ascendant, < 0 : descendant)</param>
        ///<returns></returns>
        IClientOrderer OrderByAchatCumule(int direction);

        /// <summary>
        /// Filtrer par ville
        /// </summary>
        /// <param name="city">Ville du client</param>
        /// <param name="callback">Fonction qui réapplique les filtres</param>
        ///<returns></returns>
        IClientOrderer FilterByCity(string city, DelReApplyFilter callback);

        void ResetFilter();

        IQueryable<Client> ClientResultSet { get; set; }

        /// <summary>
        /// Collecter le résultat des filtres
        /// </summary>
        ///<returns>Résultat des filtres</returns>
        IQueryable<Client> Collect();
    }
}