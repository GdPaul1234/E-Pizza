using Projet_Pizzeria.DAO;
using Projet_Pizzeria.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour NewCommandeDialog.xaml
    /// </summary>
    public partial class NewCommandeDialog : Window
    {
        public ObservableCollection<Boisson> Boissons = new ObservableCollection<Boisson>(AItemDataStore.Boissons);
        public ObservableCollection<Pizza> Pizzas = new ObservableCollection<Pizza>(AItemDataStore.Pizzas);
        private readonly CollectionViewSource boissonViewSource;
        private readonly CollectionViewSource pizzaViewSource;

        public Commande NewCommande { get; private set; }

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

        private void AddBoisson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPizza_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            // create "returned" commande from fields value
            // TODO ...

            DialogResult = true;
        }

        private void DelItem_Click(object sender, RoutedEventArgs e)
        {

        }
       
    }
}
