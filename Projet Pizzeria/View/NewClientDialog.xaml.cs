using Projet_Pizzeria.Model;
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
    /// Logique d'interaction pour NewClientDialog.xaml
    /// </summary>
    public partial class NewClientDialog : Window
    {
        public Client NewClient { get; private set; }

        public NewClientDialog()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            // select the first field (Nom client)
            nom.SelectAll();
            nom.Focus();
        }

        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            // create "returned" client from fields value
            NewClient = new Client
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

            DialogResult = true;
        }

    }
}
