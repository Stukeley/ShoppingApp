using System.Windows.Controls;
using ShoppingApp.Models;
using ShoppingApp.Services;

namespace ShoppingApp.Views.UserControls;

public partial class ProductControl : UserControl
{
    public ProductControl(CartService cartService, Product product)
    {
        InitializeComponent();
        
        this.DataContext = new ViewModels.ProductViewModel(cartService, product);
    }
}