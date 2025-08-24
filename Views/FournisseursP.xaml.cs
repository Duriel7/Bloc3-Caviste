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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bloc3_Caviste.Views
{
    /// <summary>
    /// Logique d'interaction pour Fournisseurs.xaml
    /// </summary>
    public partial class Fournisseurs : Page
    {
        public Fournisseurs()
        {
            InitializeComponent();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SwitchToCMD(object sender, RoutedEventArgs e)
        {

        }

        private void AjtFournisseur(object sender, RoutedEventArgs e)
        {
            FournisseurCreate fournisseurCreateWindow = new FournisseurCreate();
            fournisseurCreateWindow.ShowDialog();
        }
    }
}
