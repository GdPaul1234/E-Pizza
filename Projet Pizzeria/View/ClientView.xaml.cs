using Projet_Pizzeria.Controller;
using Projet_Pizzeria.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour ClientView.xaml
    /// </summary>
    public partial class ClientView : UserControl
    {

        private readonly ModuleClientEffectif _controller = new ModuleClientEffectif();
        private readonly CollectionViewSource clientViewSource;

        public ClientView()
        {
            InitializeComponent();
            clientViewSource = FindResource(nameof(clientViewSource)) as CollectionViewSource;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // bind to the source
            clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
        }

        private Client GetSelectedClientFromButtonTag(object sender)
        {
            // get data from datagrid on button click in WPF application
            // https://stackoverflow.com/questions/5836814/get-data-from-datagrid-on-button-click-in-wpf-application#5836962
            var button = sender as FrameworkElement;
            return button.Tag as Client;
        }

        private void EditClient_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedClient = GetSelectedClientFromButtonTag(sender);
            if(selectedClient != null)
            {
                #region NEW CLIENT
                var editClient = new Client
                {
                    Nom = nom.Text,
                    Prenom = prenom.Text,
                    NoTelephone = telephone.Text,
                    Adresse = new Adresse
                    {
                        Rue = adresseRue.Text,
                        Ville = adresseVille.Text,
                        Cp = adresseCp.Text
                    },
                };
                #endregion

                _controller.EditClient(selectedClient.NoClient, editClient);

                // manual refresh
                System.Diagnostics.Trace.WriteLine($"Client {selectedClient.NoClient} edited");
                clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
            }
        }

        private void DelClient_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedClient = GetSelectedClientFromButtonTag(sender);
            _controller.DelClient(selectedClient.NoClient);

            // manual refresh
            System.Diagnostics.Trace.WriteLine($"Client {selectedClient.NoClient} deleted");
            clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
        }

        private void AddClient_Button_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new NewClientDialog();
            if (inputDialog.ShowDialog() == true)
            {
                long cId = _controller.AddClient(inputDialog.NewClient);

                // manual refresh
                System.Diagnostics.Trace.WriteLine($"Client {cId} added to DB");
                clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
            }
        }
    }
}
