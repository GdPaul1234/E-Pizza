using System.Windows;

namespace Projet_Pizzeria
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Reste à tester la réception
            //Envoyer un message de commis vers cuisine
            //ModuleCommunication.SendMessage(Exchanges.COMMIS_CUISINE_EXCHANGE, RoutingKeys.ROUTING_KEY, "La commande est prise");
            //Recevoir le message de commis
            //Console.WriteLine("Message received is " + ModuleCommunication.ReceiveMessage(Queues.COMMIS_CUISINE_QUEUE));
        }
    }
}