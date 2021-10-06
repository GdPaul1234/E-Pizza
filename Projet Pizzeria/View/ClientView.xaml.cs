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

        private void EditClient_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void DelClient_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // get data from datagrid on button click in WPF application
            // https://stackoverflow.com/questions/5836814/get-data-from-datagrid-on-button-click-in-wpf-application#5836962
            var button = sender as FrameworkElement;
            var selectedClient = button.Tag as Client;
            _controller.DelClient(selectedClient.NoClient);

            // refresh
            clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
        }

        private void AddClient_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
