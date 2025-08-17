using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bloc3_Caviste
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Ajout: initialisation du ViewModel pour rétablir les liaisons
            DataContext = new MainWindowViewModel();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                ToggleMaxRestore();
                return;
            }
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void BtnMin_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void BtnMax_Click(object sender, RoutedEventArgs e) => ToggleMaxRestore();

        private void ToggleMaxRestore()
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }
    }
}