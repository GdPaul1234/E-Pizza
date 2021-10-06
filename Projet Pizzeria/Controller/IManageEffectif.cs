namespace Projet_Pizzeria.Model
{
    public interface IManageEffectif
    {

        /// <summary>
        /// Ajouter un client dans la db de la pizerria
        /// </summary>
        /// <param name="c">Client � ajouter</param>
        /// <returns>long idClient</returns>
        long AddClient(Client c);

        /// <summary>
        /// Supprimer un client de la db de la pizerria
        /// </summary>
        /// <param name="noClient">idClient � supprimer</param>
        /// <returns></returns>
        void EditClient(long noClient, Client c);

        /// <summary>
        /// Editer un client de la db de la pizerria
        /// </summary>
        /// <param name="noClient">idClient � �diter</param>
        /// <returns></returns>
        void DelClient(long noClient);

    }
}
