using Projet_Pizzeria.Controller;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour StatView.xaml
    /// </summary>
    public partial class StatsView : UserControl
    {
        private readonly ModuleStatistiques _controller = new ModuleStatistiques();

        public string MoyenneCommandes { get; private set; }
        public string MoyenneCompteClient { get; private set; }

        public StatsView()
        {
            InitializeComponent();
            DataContext = this;

            ReCalculateStats();
        }

        private void ReCalculateStats()
        {
            MoyenneCommandes = $"{_controller.GetAvgPrixCommande():C}";
            MoyenneCompteClient = $"{_controller.GetAvgPrixClient():C}";
        }

        private void Refresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ReCalculateStats();
        }
    }
}