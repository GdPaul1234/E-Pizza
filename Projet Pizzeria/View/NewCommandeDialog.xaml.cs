using Projet_Pizzeria.Controller;
using Projet_Pizzeria.DAO;
using Projet_Pizzeria.Model;
using Projet_Pizzeria.Model.Controller;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour NewCommandeDialog.xaml
    /// </summary>
    public partial class NewCommandeDialog : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Boisson> Boissons = new ObservableCollection<Boisson>(AItemDataStore.Boissons);
        public ObservableCollection<Pizza> Pizzas = new ObservableCollection<Pizza>(AItemDataStore.Pizzas);
        private readonly CollectionViewSource boissonViewSource;
        private readonly CollectionViewSource pizzaViewSource;

        private readonly ModuleClientEffectif _clientController = new ModuleClientEffectif();
        private readonly ModuleCommandes _controller = new ModuleCommandes();

        public Commande NewCommande { get; private set; } = new Commande();
        public Client Client { get; set; }
        private int _nbPizza;

        public NewCommandeDialog()
        {
            InitializeComponent();
            DataContext = this;

            boissonViewSource = FindResource(nameof(boissonViewSource)) as CollectionViewSource;
            pizzaViewSource = FindResource(nameof(pizzaViewSource)) as CollectionViewSource;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // bind to the source
            boissonViewSource.Source = Boissons;
            pizzaViewSource.Source = Pizzas;
        }

        #region Add client to commande
        private void CreateClient_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new NewClientDialog { Owner = Application.Current.MainWindow };

            if (inputDialog.ShowDialog() == true)
            {
                Client = inputDialog.NewClient;
                long cId = _clientController.AddClient(Client);
                RaisePropertyChanged("Client");

                System.Diagnostics.Trace.TraceInformation($"Client {cId} added to DB");
            }
        }

        private void FindClientByPhone_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new AskNoTelephoneClientDialog { Owner = Application.Current.MainWindow };

            if (inputDialog.ShowDialog() == true)
            {
                Client = _controller.FindClientByPhone(inputDialog.NoTelephone);
                RaisePropertyChanged("Client");
            }
        }
        #endregion // Add client to commande

        #region Add item to commande
        private void AddBoisson_Click(object sender, RoutedEventArgs e)
        {
            var selectedBoisson = boissonComboBox.SelectedItem as Boisson;
            NewCommande.AddItem(selectedBoisson);
            RaisePropertyChanged("NewCommande");
        }

        private void AddPizza_Click(object sender, RoutedEventArgs e)
        {
            var selectedPizza = pizzaComboBox.SelectedItem as Pizza;
            NewCommande.AddItem(selectedPizza);
            _nbPizza++;
            RaisePropertyChanged("NewCommande");
        }
        
        private void DelItem_Click(object sender, RoutedEventArgs e)
        {
            AItem selectedItem = (sender as FrameworkElement).Tag as AItem;
            if(selectedItem != null)
            {
                NewCommande.DelItem(selectedItem);
                _nbPizza++;
                RaisePropertyChanged("NewCommande");
            }
           
        }
        #endregion // Add item to commande


        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            // create "returned" commande from fields value
            if(Client != null && _nbPizza > 0)
            {
                _controller.CreateNouvelleCommande(Client, NewCommande);
                DialogResult = true;
            }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion // INotifyPropertyChanged implementation

    }
}
