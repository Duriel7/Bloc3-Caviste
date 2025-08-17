using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bloc3_Caviste.Views
{

    public partial class Caisse : Window
    {
        private readonly CaisseViewModel _vm;
        public Caisse()
        {
            InitializeComponent();
            _vm = new CaisseViewModel();
            DataContext = _vm; // Assure l'alimentation des DataGrid
        }

        //Gestion de la Fenetre
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

        private void BtnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            _vm.SearchKeyword = string.Empty;
        }

        // Handlers DataGrid Produits
        private void ProductsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_vm.SelectedProduct != null)
                _vm.AddSelectedProduct(_vm.SelectedProduct);
        }

        private void AddProductMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.SelectedProduct != null)
                _vm.AddSelectedProduct(_vm.SelectedProduct);
        }

        // Handlers DataGrid Sélection
        private void SelectedProductsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_vm.SelectedSelectedProduct != null)
                _vm.RemoveSelectedProduct(_vm.SelectedSelectedProduct);
        }

        private void SelectedProductsDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && _vm.SelectedSelectedProduct != null)
            {
                _vm.RemoveSelectedProduct(_vm.SelectedSelectedProduct);
            }
        }

        private void RemoveSelectedProductMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.SelectedSelectedProduct != null)
                _vm.RemoveSelectedProduct(_vm.SelectedSelectedProduct);
        }

        private void ClearSelectedProducts_Click(object sender, RoutedEventArgs e)
        {
            _vm.SelectedProducts.Clear();
        }

        // Gestion de la Recherche (simplifiée filtrage en mémoire)
        private void SearchBarProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            _vm.ApplyProductFilter();
        }
    }

    // ViewModel simple interne (peut être déplacé dans un dossier ViewModels)
    public class CaisseViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        private string _searchKeyword = string.Empty;
        public string SearchKeyword
        {
            get => _searchKeyword;
            set { if (_searchKeyword != value) { _searchKeyword = value; OnPropertyChanged(nameof(SearchKeyword)); ApplyProductFilter(); } }
        }

        public ObservableCollection<ProductItem> AllProducts { get; } = new();
        public ObservableCollection<ProductItem> Products { get; } = new();
        public ObservableCollection<SelectedProductItem> SelectedProducts { get; } = new();

        private ProductItem? _selectedProduct;
        public ProductItem? SelectedProduct { get => _selectedProduct; set { _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct)); } }

        private SelectedProductItem? _selectedSelectedProduct;
        public SelectedProductItem? SelectedSelectedProduct { get => _selectedSelectedProduct; set { _selectedSelectedProduct = value; OnPropertyChanged(nameof(SelectedSelectedProduct)); } }

        public CaisseViewModel()
        {
            // Données d'exemple pour rendre visibles les tableaux
            var rnd = new Random();
            string[] noms = {"Bordeaux Rouge","Champagne Brut","Côtes du Rhône","Chablis","Rosé Provence","Sancerre"};
            for (int i = 0; i < noms.Length; i++)
            {
                var p = new ProductItem
                {
                    Code = $"P{i+1:000}",
                    Name = noms[i],
                    Price = Math.Round(rnd.NextDouble() * 25 + 5, 2),
                    Stock = rnd.Next(5, 80)
                };
                AllProducts.Add(p);
            }
            ApplyProductFilter();
        }

        public void ApplyProductFilter()
        {
            Products.Clear();
            var query = string.IsNullOrWhiteSpace(SearchKeyword)
                ? AllProducts
                : new ObservableCollection<ProductItem>(AllProducts.Where(p => p.Name.Contains(SearchKeyword, StringComparison.OrdinalIgnoreCase) || p.Code.Contains(SearchKeyword, StringComparison.OrdinalIgnoreCase)));
            foreach (var p in query) Products.Add(p);
        }

        public void AddSelectedProduct(ProductItem product)
        {
            var existing = SelectedProducts.FirstOrDefault(s => s.Code == product.Code);
            if (existing != null)
            {
                existing.Quantity += 1;
                existing.UpdateTotals();
            }
            else
            {
                SelectedProducts.Add(new SelectedProductItem
                {
                    Code = product.Code,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            OnPropertyChanged(nameof(SelectedProducts));
        }

        public void RemoveSelectedProduct(SelectedProductItem item)
        {
            SelectedProducts.Remove(item);
            OnPropertyChanged(nameof(SelectedProducts));
        }

        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
    }

    public class ProductItem
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Stock { get; set; }
    }

    public class SelectedProductItem : System.ComponentModel.INotifyPropertyChanged
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        private int _quantity;
        public int Quantity { get => _quantity; set { if (_quantity != value) { _quantity = value; UpdateTotals(); OnPropertyChanged(nameof(Quantity)); OnPropertyChanged(nameof(TotalPrice)); } } }
        public double TotalPrice => Math.Round(Price * Quantity, 2);

        public void UpdateTotals() => OnPropertyChanged(nameof(TotalPrice));

        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
    }
}
