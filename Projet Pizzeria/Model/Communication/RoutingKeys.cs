namespace Projet_Pizzeria.Model.Communication
{
    internal static class RoutingKeys
    {
        public const string PREPARATION_CLIENT = "preparation.client";
        public const string PREPARATION_CUISINE = "preparation.cuisine";
        public const string PREPARATION_LIVREUR = "preparation.livreur";
        public const string PREPARATION_COMMIS = "preparation.commis";

        public const string LIVRAISON_LIVREUR = "livraison.livreur";

        public const string FERMEE_LIVREUR = "fermeture.livreur";
        public const string FERMEE_COMMIS = "fermeture.commis";

        public const int LIVREUR_PREPARATION_DELAY = 5000; // en ms
    }
}