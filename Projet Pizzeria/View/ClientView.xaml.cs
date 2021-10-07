using Projet_Pizzeria.Controller;
using Projet_Pizzeria.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour ClientView.xaml
    /// </summary>
    public partial class ClientView : UserControl
    {

        private readonly ModuleClientEffectif _controller = new ModuleClientEffectif();
        private readonly CollectionViewSource clientViewSource;

        public ToggleButtonLogic ToggleButtonLogic { get; set; } = new ToggleButtonLogic();

        public ClientView()
        {
            InitializeComponent();
            DataContext = this;

            clientViewSource = FindResource(nameof(clientViewSource)) as CollectionViewSource;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _controller.ClientResultSet.Load();

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

        #region CRUD Client Handler
        private void EditClient_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = GetSelectedClientFromButtonTag(sender);
            if (selectedClient != null)
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
                #endregion // NEW CLIENT

                _controller.EditClient(selectedClient.NoClient, editClient);

                // manual refresh
                System.Diagnostics.Trace.WriteLine($"Client {selectedClient.NoClient} edited");
                clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
            }
        }

        private void DelClient_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = GetSelectedClientFromButtonTag(sender);
            _controller.DelClient(selectedClient.NoClient);

            // manual refresh
            System.Diagnostics.Trace.WriteLine($"Client {selectedClient.NoClient} deleted");
            clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
        }

        private void AddClient_Button_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new NewClientDialog { Owner = Application.Current.MainWindow };

            if (inputDialog.ShowDialog() == true)
            {
                long cId = _controller.AddClient(inputDialog.NewClient);

                // manual refresh
                System.Diagnostics.Trace.WriteLine($"Client {cId} added to DB");
                clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
            }
        }
        #endregion // CRUD Client Handler

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            _controller.ResetFilter();

            // reset UI
            ToggleButtonLogic.ResetToggleButtons();

            // manual refresh
            System.Diagnostics.Trace.WriteLine($"Reset filter");
            clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Get filter sender
            var filterToBeApplied = sender as FrameworkElement;

            switch (filterToBeApplied.Name)
            {
                case "orderNameAsc": _controller.OrderByAlphaOrder(1).Collect(); break;
                case "orderNameDesc": _controller.OrderByAlphaOrder(-1).Collect(); break;
                case "orderAchatsAsc": _controller.OrderByAchatCumule(1).Collect(); break;
                case "orderAchatsDesc": _controller.OrderByAchatCumule(-1).Collect(); break;
            }

            // manual refresh
            System.Diagnostics.Trace.WriteLine($"Filter applied");
            clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
        }

        private void ClientDataGrid_DisableSorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;
        }
    }

    #region ToggleButton Logic
    public class ToggleButtonLogic : INotifyPropertyChanged
    {
        private bool _orderAlphaAsc = false, _orderAlphaDesc = false;
        private bool _orderAchatsAsc = false, _orderAchatsDesc = false;

        public bool OrderAlphaAsc
        {
            get => _orderAlphaAsc;
            set
            {
                if (value)
                    _orderAlphaDesc = false;
                if (value || !_orderAlphaAsc)
                    _orderAlphaAsc = value;
                OnPropertyChanged("OrderAlphaAsc");
                OnPropertyChanged("OrderAlphaDesc");
            }
        }

        public bool OrderAlphaDesc
        {
            get => _orderAlphaDesc;
            set
            {
                if (value)
                    _orderAlphaAsc = false;
                if (value || !_orderAlphaDesc)
                    _orderAlphaDesc = value;
                OnPropertyChanged("OrderAlphaAsc");
                OnPropertyChanged("OrderAlphaDesc");
            }
        }

        public bool OrderAchatsAsc
        {
            get => _orderAchatsAsc;
            set
            {
                if (value)
                    _orderAchatsDesc = false;
                if (value || !_orderAchatsAsc)
                    _orderAchatsAsc = value;
                OnPropertyChanged("OrderAchatsAsc");
                OnPropertyChanged("OrderAchatsDesc");
            }
        }

        public bool OrderAchatsDesc
        {
            get => _orderAchatsDesc;
            set
            {
                if (value)
                    _orderAchatsAsc = false;
                if (value || !_orderAchatsDesc)
                    _orderAchatsDesc = value;
                OnPropertyChanged("OrderAchatsAsc");
                OnPropertyChanged("OrderAchatsDesc");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string new_Value = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(new_Value));
        }

        public void ResetToggleButtons()
        {
            _orderAlphaAsc = _orderAlphaDesc = false;
            _orderAchatsAsc = _orderAchatsDesc = false;

            // reset smart toggle state
            OrderAlphaAsc = OrderAlphaDesc = false;
            OrderAchatsAsc = OrderAchatsDesc = false;
        }
    }
    #endregion // ToggleButton Logic
}
