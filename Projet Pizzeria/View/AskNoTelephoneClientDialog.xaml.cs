using System.Windows;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour AskNoTelephoneClientDialog.xaml
    /// </summary>
    public partial class AskNoTelephoneClientDialog : Window
    {
        public string NoTelephone { get; set; }

        public AskNoTelephoneClientDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}