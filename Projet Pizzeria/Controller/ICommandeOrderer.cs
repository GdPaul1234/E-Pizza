using Projet_Pizzeria.Model;
using System.Linq;

namespace Projet_Pizzeria.Controller
{
    public interface ICommandeOrderer
    {
        /// <summary>
        /// Filtrer les commandes selon leur état
        /// </summary>
        /// <param name="etat">Etat de la commande</param>
        ///<returns></returns>
        ICommandeOrderer FilterByEtat(string etat);

        /// <summary>
        /// Rechercher une commande particulière
        /// </summary>
        /// <param name="numeroCommande">Numéro de la commande</param>
        ///<returns></returns>
        ICommandeOrderer SearchByNumber(long numeroCommande);

        void ResetFilter();

        IQueryable<Commande> CommandeResultSet { get; set; }

        /// <summary>
        /// Collecter le résultat des filtres
        /// </summary>
        ///<returns>Résultat des filtres</returns>
        IQueryable<Commande> Collect();
    }
}