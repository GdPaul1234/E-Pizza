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
