using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour ImportPersonneDialog.xaml
    /// </summary>
    public partial class ImportPersonneDialog : Window
    {
        public ImportPersonneDialog()
        {
            InitializeComponent();
        }

        private string OpenFileDialog()
        {
            // Comment ouvrir une boîte de dialogue commune (WPF .NET)
            // https://docs.microsoft.com/fr-fr/dotnet/desktop/wpf/windows/how-to-open-common-system-dialog-box?view=netdesktop-5.0

            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "Database", // Default file name
                DefaultExt = ".db", // Default file extension
                Filter = "SQLite databases (.db)|*.db" // Filter files by extension
            };

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                return dialog.FileName;
            }
            return null;
        }

        private void ImportClients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportCommis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportLivreurs_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
