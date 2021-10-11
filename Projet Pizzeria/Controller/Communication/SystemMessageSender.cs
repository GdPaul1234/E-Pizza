using Projet_Pizzeria.Model;
using Projet_Pizzeria.Model.Communication;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Pizzeria.Controller.Communication
{
    public static class SystemMessageSender
    {
        public static void SendPrepartionMessages(Commande commande)
        {
            string dateNow = DateTime.Now.ToString("s"); // ex: 2009-06-15T13:45:30

            // Client
            ModuleCommunication.PublishMessage(RoutingKeys.PREPARATION_CLIENT,
                $"{dateNow}: Prise en charge commande {commande.NumeroCommande}");

            // Cuisine
            StringBuilder messageCuisine = new StringBuilder($"{dateNow}: Commande {commande.NumeroCommande}:");
            foreach (var item in commande.Items)
            {
                if (item is Pizza) messageCuisine.AppendLine($" - {item as Pizza}");
            }

            ModuleCommunication.PublishMessage(RoutingKeys.PREPARATION_CUISINE, messageCuisine.ToString());

            // Livreur
            Task.Delay(RoutingKeys.LIVREUR_PREPARATION_DELAY).ContinueWith((t) =>
            {
                ModuleCommunication.PublishMessage(RoutingKeys.PREPARATION_LIVREUR,
                $"{dateNow} (5 min ago): Commande à livrer {commande.NumeroCommande} au {commande.Client.Adresse}");
            });

            // Commis
            ModuleCommunication.PublishMessage(RoutingKeys.PREPARATION_COMMIS,
                $"{dateNow}: Confirmation: Ouverture commande {commande.NumeroCommande}");
        }

        public static void SendLivraisonMessages(Commande commande)
        {
            string dateNow = DateTime.Now.ToString("s"); // ex: 2009-06-15T13:45:30

            // Livreur
            ModuleCommunication.PublishMessage(RoutingKeys.LIVRAISON_LIVREUR,
                $"{dateNow}: Confirmation: {commande.NumeroCommande} livrée chez {commande.Client}");
        }

        public static void SendFermetureMessages(Commande commande)
        {
            string dateNow = DateTime.Now.ToString("s"); // ex: 2009-06-15T13:45:30

            // Livreur
            ModuleCommunication.PublishMessage(RoutingKeys.LIVRAISON_LIVREUR,
                $"{dateNow}: Fermeture commande {commande.NumeroCommande} ({commande.MontantTotal:C})");

            // Commis
            ModuleCommunication.PublishMessage(RoutingKeys.PREPARATION_COMMIS,
                $"{dateNow}: Confirmation: fermeture commande {commande.NumeroCommande}");
        }
    }
}