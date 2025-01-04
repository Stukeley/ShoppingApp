using System.Windows;
using System.Windows.Input;
using ShoppingApp.Services;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Views;

public partial class MainWindow : Window
{
    private readonly MainViewModel _mainViewModel;
    private readonly CartService _cartService = new();
    
    public MainWindow()
    {
        InitializeComponent();

        _mainViewModel = new MainViewModel(_cartService);

        this.DataContext = _mainViewModel;
    }

    private void TopPanel_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }

    private void MinimizeButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void ExitButton_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void ButtonCloseMenu_OnClick(object sender, RoutedEventArgs e)
    {
        ButtonCloseMenu.Visibility = Visibility.Collapsed;
        ButtonOpenMenu.Visibility = Visibility.Visible;
    }

    private void ButtonOpenMenu_OnClick(object sender, RoutedEventArgs e)
    {
        ButtonOpenMenu.Visibility = Visibility.Collapsed;
        ButtonCloseMenu.Visibility = Visibility.Visible;
    }

    private void AllProducts_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        var productRepository = new ProductRepository();
        var page = new Pages.MainPage(_cartService, productRepository.GetProducts());
        MainFrame.Content = page;
    }

    private void CartPopup_OnOpened(object sender, RoutedEventArgs e)
    {
        _mainViewModel.PopupOpenCommand.Execute(e);
    }
}