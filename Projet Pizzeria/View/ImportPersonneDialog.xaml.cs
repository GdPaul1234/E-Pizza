using Projet_Pizzeria.Controller;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour ImportPersonneDialog.xaml
    /// </summary>
    public partial class ImportPersonneDialog : Window
    {
        private readonly char sep = Path.DirectorySeparatorChar;
        private readonly string DbFolderPath;

        public ImportPersonneDialog()
        {
            InitializeComponent();

            DbFolderPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{sep}Pizzeria";
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
            var _controller = new ModuleClientEffectif();
            string filename = OpenFileDialog();
            if (filename != null && filename.Split('\\').Last() == "clients.db")
            {
                File.Copy(filename, Path.Combine(DbFolderPath, "clients.db"), true);
                try
                {
                    _controller.ImportClient();
                }
                catch (Exception err)
                {
                    System.Diagnostics.Trace.TraceError(err.Message);
                    System.Diagnostics.Trace.TraceError(err?.InnerException.Message);
                    MessageBox.Show(err?.InnerException.Message,
                    "Erreur importation", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("L'importation a échouée.\nNom de fichier invalide (!= 'clients.db)'",
                    "Erreur importation", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ImportCommis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportLivreurs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
