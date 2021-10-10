using Microsoft.EntityFrameworkCore;
using Projet_Pizzeria.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Projet_Pizzeria.Controller;
using System.IO;
using System.Linq;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour CommandeView.xaml
    /// </summary>
    public partial class CommandeView : UserControl
    {
        private readonly ModuleCommandes _controller = new ModuleCommandes();
        private readonly CollectionViewSource commandeViewSource;

        private static readonly char sep = Path.DirectorySeparatorChar;
        private static readonly string _dbFolderPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{sep}Pizzeria";
        private static readonly string _backupDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}{sep}PizzeriaBackup";

        public ThreeStateToggleButtonLogic ThreeStateToggleButtonLogic { get; set; } = new ThreeStateToggleButtonLogic();

        public CommandeView()
        {
            InitializeComponent();
            DataContext = this;

            commandeViewSource = FindResource(nameof(commandeViewSource)) as CollectionViewSource;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _controller.CommandeResultSet.Load();

            // bind to the source
            commandeViewSource.Source = new ObservableCollection<Commande>(_controller.CommandeResultSet);
        }

        private void AddCommande_Click(object sender, RoutedEventArgs e)
        {
            NewCommandeDialog inputDialog = new NewCommandeDialog { Owner = Application.Current.MainWindow };
            if (inputDialog.ShowDialog() == true)
            {
                // manual refresh
                System.Diagnostics.Trace.TraceInformation("Commande added to DB");
                commandeViewSource.Source = new ObservableCollection<Commande>(_controller.CommandeResultSet);
            }
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            _controller.ResetFilter();

            // reset UI
            ThreeStateToggleButtonLogic.ResetToggleButtons();
            NoCommandeTextBox.Text = "";

            // manual refresh
            System.Diagnostics.Trace.TraceInformation("Reset filter");
            commandeViewSource.Source = new ObservableCollection<Commande>(_controller.CommandeResultSet);
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Get filter sender
            var filterToBeApplied = sender as FrameworkElement;

            switch (filterToBeApplied.Name)
            {
                case "Preparation": _controller.FilterByEtat("En préparation").Collect(); break;
                case "Livraison": _controller.FilterByEtat("En livraison").Collect(); break;
                case "Fermee": _controller.FilterByEtat("Fermée").Collect(); break;
                default: break;
            }

            // manual refresh
            System.Diagnostics.Trace.TraceInformation("Filter applied");
            commandeViewSource.Source = new ObservableCollection<Commande>(_controller.CommandeResultSet);
        }

        private void NoCommandeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string commandeIdSearch = (sender as TextBox).Text;
            if (string.IsNullOrWhiteSpace(commandeIdSearch)) _controller.ResetFilter();
            else if (long.TryParse(commandeIdSearch, out long numeroCommande))
            {
                _controller.SearchByNumber(numeroCommande);
            }
            // manual refresh
            commandeViewSource.Source = new ObservableCollection<Commande>(_controller.CommandeResultSet);
        }

        private void EditCommande_Click(object sender, RoutedEventArgs e)
        {
            Commande selectedCommande = (sender as FrameworkElement).Tag as Commande;
            if (selectedCommande != null)
            {
                _controller.EditCommande(selectedCommande.NumeroCommande, new Commande
                {
                    EtatCommande = etatCommande.Text,
                    EstEncaissee = (bool)estEncaissee.IsChecked ? 1 : 0
                });
            }
        }

        #region Import Export Handler

        private void ExportCommandes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _controller.ExportCommande(); // Do nothing, see implementation comments

                var fName = "commandes.db";

                Directory.CreateDirectory(_backupDir);
                File.Copy(Path.Combine(_dbFolderPath, "pizzeria.db"), Path.Combine(_backupDir, fName), true);

                System.Diagnostics.Process.Start("explorer.exe", _backupDir);
                System.Diagnostics.Trace.TraceInformation("Export successfully!");
            }
            catch (Exception err)
            {
                System.Diagnostics.Trace.TraceError(err.StackTrace);
            }
        }

        private void ImportCommandes_Click(object sender, RoutedEventArgs e)
        {
            string filename = ImportPersonneDialog.OpenFileDialog();
            string entityName = "commandes.db";

            if (filename != null && Path.GetFileName(filename) == entityName)
            {
                var askQuestion = MessageBox.Show("Cette opération va remplacer les données actuelles\n Continuer ?",
                    "Importation commandes", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (askQuestion == MessageBoxResult.Yes)
                {
                    try
                    {
                        _controller.ImportCommande(); // Do nothing, see implementation comments

                        File.Copy(filename, Path.Combine(_dbFolderPath, "pizzeria.db"), true);

                        // Restart the application
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Trace.TraceError(err.Message);
                        MessageBox.Show(err.Message,
                        "Erreur importation", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show($"L'importation a échouée.\nNom de fichier invalide (!= '{entityName}')",
                   "Erreur importation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion Import Export Handler
    }

    #region ThreeStatToggleeButtonLogic

    public class ThreeStateToggleButtonLogic : INotifyPropertyChanged
    {
        private bool _preparation = true, _livraison = false, _fermee = false;

        public bool EnPreparation
        {
            get => _preparation;
            set
            {
                if (value) _livraison = _fermee = false;
                _preparation = value;
                OnPropertyChanged("EnPreparation");
                OnPropertyChanged("EnLivraison");
                OnPropertyChanged("EnFermee");
            }
        }

        public bool EnLivraison
        {
            get => _livraison;
            set
            {
                if (value) _preparation = _fermee = false;
                _livraison = value;
                OnPropertyChanged("EnPreparation");
                OnPropertyChanged("EnLivraison");
                OnPropertyChanged("EnFermee");
            }
        }

        public bool EnFermee
        {
            get => _fermee;
            set
            {
                if (value) _livraison = _preparation = false;
                _fermee = value;
                OnPropertyChanged("EnPreparation");
                OnPropertyChanged("EnLivraison");
                OnPropertyChanged("EnFermee");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string new_Value = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(new_Value));
        }

        public void ResetToggleButtons()
        {
            _preparation = true;
            _livraison = _fermee = false;
        }
    }

    #endregion ThreeStatToggleeButtonLogic

    #region IntToBooleanValueConverter

    public class IntToBooleanValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (int)value != 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool boolean ?
                boolean ? 1 : 0
                : 0 as object;
        }
    }

    #endregion IntToBooleanValueConverter
}