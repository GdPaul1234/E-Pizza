using Projet_Pizzeria.Model;
using System.Collections.Generic;

namespace Projet_Pizzeria.Controller
{
    public interface IClientOrderer
    {
        /// <summary>
        /// Trier par ordre alphabéthique
        /// </summary>
        /// <param name="direction">direction (> 0 : ascendant, < 0 : descendant)</param>
        ///<returns></returns>
        IClientOrderer OrderByAlphaOrder(int direction);

        /// <summary>
        /// Trier par ordre alphabéthique
        /// </summary>
        ///<returns></returns>
        IClientOrderer OrderByAchatCumule();

        /// <summary>
        /// Filtrer par ville
        /// </summary>
        /// <param name="city">Ville du client</param>
        ///<returns></returns>
        IClientOrderer FilterByCity(string city);

        List<Client> ClientResultSet { get; set; }

        /// <summary>
        /// Collecter le résultat des filtres
        /// </summary>
        ///<returns>Résultat des filtres</returns>
        List<Client> Collect();
    }
}
