using Microsoft.EntityFrameworkCore;
using Projet_Pizzeria.Controller;
using Projet_Pizzeria.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
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

        public ToggleButtonLogic ToggleButtonLogic { get; set; } = new ToggleButtonLogic();

        public ClientView()
        {
            InitializeComponent();
            DataContext = this;

            clientViewSource = FindResource(nameof(clientViewSource)) as CollectionViewSource;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _controller.ResetFilter();

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

                #endregion NEW CLIENT

                _controller.EditClient(selectedClient.NoClient, editClient);

                // manual refresh
                System.Diagnostics.Trace.TraceInformation($"Client {selectedClient.NoClient} edited");
                clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
            }
        }

        private void DelClient_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = GetSelectedClientFromButtonTag(sender);
            if(selectedClient != null)
            {
                _controller.DelClient(selectedClient.NoClient);
                // manual refresh
                System.Diagnostics.Trace.TraceInformation($"Client {selectedClient.NoClient} deleted");
                clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
            }
        }

        private void AddClient_Button_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new NewClientDialog { Owner = Application.Current.MainWindow };

            if (inputDialog.ShowDialog() == true)
            {
                long cId = _controller.AddClient(inputDialog.NewClient);

                // manual refresh
                System.Diagnostics.Trace.TraceInformation($"Client {cId} added to DB");
                clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
            }
        }

        #endregion CRUD Client Handler

        #region Filter Handler

        private void ClientDataGrid_DisableSorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            _controller.ResetFilter();

            // reset UI
            ToggleButtonLogic.ResetToggleButtons();
            CitySearch.Text = "";

            // manual refresh
            System.Diagnostics.Trace.TraceInformation($"Reset filter");
            clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
        }

        private void ReApplyFilter()
        {
            if (ToggleButtonLogic.OrderAchatsAsc) _controller.OrderByAlphaOrder(1).Collect();
            if (ToggleButtonLogic.OrderAchatsDesc) _controller.OrderByAlphaOrder(-1).Collect();
            if (ToggleButtonLogic.OrderAchatsAsc) _controller.OrderByAchatCumule(1).Collect();
            if (ToggleButtonLogic.OrderAchatsDesc) _controller.OrderByAchatCumule(-1).Collect();

            // manual refresh
            System.Diagnostics.Trace.TraceInformation($"Filter re-applied");
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
                default: break;
            }

            // manual refresh
            System.Diagnostics.Trace.TraceInformation("Filter applied");
            clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
        }

        private void CitySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var citySearch = sender as TextBox;
            var searchQuery = citySearch.Text;

            _controller.FilterByCity(searchQuery, ReApplyFilter).Collect();

            // manual refresh
            System.Diagnostics.Trace.TraceInformation($"Filter by city containing '{searchQuery}'");
            clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
        }

        #endregion Filter Handler

        #region Import Export Handler

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _controller.ExportClient();
                _controller.ExportCommis();
                _controller.ExportLivreur();

                var sep = Path.DirectorySeparatorChar;
                var DbFolderPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{sep}Pizzeria";
                var backupDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}{sep}PizzeriaBackup";
                var exportFNames = new string[] { "clients.db", "commis.db", "livreurs.db" };

                Directory.CreateDirectory(backupDir);

                foreach (var fName in exportFNames)
                {
                    File.Copy(Path.Combine(DbFolderPath, fName), Path.Combine(backupDir, fName), true);
                }

                System.Diagnostics.Process.Start("explorer.exe", backupDir);
                System.Diagnostics.Trace.TraceInformation("Export successfully!");
            }
            catch(Exception err)
            {
                System.Diagnostics.Trace.TraceError(err.StackTrace);
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new ImportPersonneDialog() { Owner = Application.Current.MainWindow };

            if(inputDialog.ShowDialog() == true) {
                // manual refresh
                System.Diagnostics.Trace.TraceInformation("Import successfully!");
                clientViewSource.Source = new ObservableCollection<Client>(_controller.ClientResultSet);
            }


        }

        #endregion // Import Export Handler

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

    #endregion ToggleButton Logic
}