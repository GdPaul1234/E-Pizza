﻿using Microsoft.EntityFrameworkCore;
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

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour CommandeView.xaml
    /// </summary>
    public partial class CommandeView : UserControl
    {
        private readonly ModuleCommandes _controller = new ModuleCommandes();
        private readonly CollectionViewSource commandeViewSource;

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