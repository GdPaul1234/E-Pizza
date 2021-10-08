﻿using Microsoft.EntityFrameworkCore;
using Projet_Pizzeria.Model;
using Projet_Pizzeria.Model.Controller;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
                if (value)_livraison = _fermee = false;
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
    }

    #endregion //  ThreeStateToggleButtonLogic
}