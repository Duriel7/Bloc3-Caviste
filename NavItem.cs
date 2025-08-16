using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using Bloc3_Caviste.Views;

namespace Bloc3_Caviste;

public class NavMenuItem
{
    public string Title { get; set; } = string.Empty;
    public PackIconKind SelectedIcon { get; set; }
    public PackIconKind UnselectedIcon { get; set; }

    // Fabrique de page associée
    public Func<Page> PageFactory { get; set; } = default!;

    public override string ToString() => Title;
}

public class MainWindowViewModel : INotifyPropertyChanged
{
    public ObservableCollection<NavMenuItem> MainMenuItems { get; }

    private NavMenuItem? _selectedMenuItem;
    public NavMenuItem? SelectedMenuItem
    {
        get => _selectedMenuItem;
        set
        {
            if (_selectedMenuItem != value)
            {
                _selectedMenuItem = value;
                OnPropertyChanged();
                UpdateCurrentPage();
            }
        }
    }

    private Page? _currentPage;
    public Page? CurrentPage
    {
        get => _currentPage;
        private set
        {
            if (_currentPage != value)
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }
    }

    public MainWindowViewModel()
    {
        MainMenuItems = new ObservableCollection<NavMenuItem>
        {
            new NavMenuItem { Title = "Accueil", SelectedIcon = PackIconKind.ViewDashboard, UnselectedIcon = PackIconKind.ViewDashboard, PageFactory = () => new Dashboard() },
            new NavMenuItem { Title = "Clients", SelectedIcon = PackIconKind.AccountGroup, UnselectedIcon = PackIconKind.AccountGroup, PageFactory = () => new Clients() },
            new NavMenuItem { Title = "Vins", SelectedIcon = PackIconKind.GlassWine, UnselectedIcon = PackIconKind.GlassWine, PageFactory = () => new Vins() },
            new NavMenuItem { Title = "Ventes", SelectedIcon = PackIconKind.ReceiptText, UnselectedIcon = PackIconKind.ReceiptText, PageFactory = () => new Ventes() },
            new NavMenuItem { Title = "Fournisseurs", SelectedIcon = PackIconKind.Truck, UnselectedIcon = PackIconKind.Truck, PageFactory = () => new Fournisseurs() },
        };

        // Sélection initiale = Accueil
        SelectedMenuItem = MainMenuItems.Count > 0 ? MainMenuItems[0] : null;
    }

    private void UpdateCurrentPage()
    {
        CurrentPage = SelectedMenuItem?.PageFactory();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}