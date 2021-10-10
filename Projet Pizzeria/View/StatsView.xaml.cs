using Projet_Pizzeria.Controller;
using Projet_Pizzeria.DAO;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using System.Windows.Data;
using System;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour StatView.xaml
    /// </summary>
    public partial class StatsView : UserControl
    {
        private readonly ModuleStatistiques _controller = new ModuleStatistiques();
        private readonly CollectionViewSource commisViewSource, livreurViewSource, commandeViewSource;

        public string MoyenneCommandes { get; private set; }
        public string MoyenneCompteClient { get; private set; }
        public DateTime DateStart { get; set; }
        public DateTime DateStop { get; set; }

        public StatsView()
        {
            InitializeComponent();
            DataContext = this;

            commisViewSource = FindResource(nameof(commisViewSource)) as CollectionViewSource;
            livreurViewSource = FindResource(nameof(livreurViewSource)) as CollectionViewSource;
            commandeViewSource = FindResource(nameof(commandeViewSource)) as CollectionViewSource;

            DateStop = DateTime.Now;
            DateStart = DateTime.Now.AddDays(-7);

            ReCalculateStats();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var _context = new PizzeriaContext())
            {
                _context.Commis.Load();
                _context.Livreurs.Load();

                // bind to the source
                commisViewSource.Source = _context.Commis.Local.ToObservableCollection();
                livreurViewSource.Source = _context.Livreurs.Local.ToObservableCollection();
                commandeViewSource.Source = _controller.GetCommandeBetweenTime(DateStart, DateStop);
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            commandeViewSource.Source = _controller.GetCommandeBetweenTime(DateStart, DateStop);
        }

        private void ReCalculateStats()
        {
            MoyenneCommandes = $"{_controller.GetAvgPrixCommande():C}";
            MoyenneCompteClient = $"{_controller.GetAvgPrixClient():C}";
        }

        private void Refresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var _context = new PizzeriaContext())
            {
                _context.Commis.Load();
                _context.Livreurs.Load();

                // bind to the source
                commisViewSource.Source = _context.Commis.Local.ToObservableCollection();
                livreurViewSource.Source = _context.Livreurs.Local.ToObservableCollection();
                commandeViewSource.Source = _controller.GetCommandeBetweenTime(DateStart, DateStop);
            }

            ReCalculateStats();
        }
    }
}