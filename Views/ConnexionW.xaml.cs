using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Bloc3_Caviste.Views
{
    public partial class Connexion : Window
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            Close();
        }

        private void CaisseButton_Click(object sender, RoutedEventArgs e)
        {
            var caisse = new Caisse();
            caisse.Show();
            Close();
        }
    }
}   
