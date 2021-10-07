using Projet_Pizzeria.Model;
using System;
using System.Windows;

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