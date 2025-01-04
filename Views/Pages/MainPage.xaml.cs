using System.Collections.Generic;
using System.Windows.Controls;
using ShoppingApp.Models;
using ShoppingApp.Services;

namespace ShoppingApp.Views.Pages;

public partial class MainPage : Page
{
    public MainPage(CartService cartService, List<Product> products)
    {
        InitializeComponent();
        
        foreach (var product in products)
        {
            var productControl = new UserControls.ProductControl(cartService, product);
            ProductsGrid.Children.Add(productControl);
        }
    }
}