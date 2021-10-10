using Projet_Pizzeria.Controller;
using Projet_Pizzeria.DAO;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using System.Windows.Data;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour StatView.xaml
    /// </summary>
    public partial class StatsView : UserControl
    {
        private readonly ModuleStatistiques _controller = new ModuleStatistiques();
        private readonly CollectionViewSource commisViewSource, livreurViewSource;

        public string MoyenneCommandes { get; private set; }
        public string MoyenneCompteClient { get; private set; }

        public StatsView()
        {
            InitializeComponent();
            DataContext = this;
            commisViewSource = FindResource(nameof(commisViewSource)) as CollectionViewSource;
            livreurViewSource = FindResource(nameof(livreurViewSource)) as CollectionViewSource;

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
            }
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
            }

            ReCalculateStats();
        }
    }
}