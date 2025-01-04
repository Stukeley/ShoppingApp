using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ShoppingApp.Models;
using ShoppingApp.Services;

namespace ShoppingApp.ViewModels;

public class ProductViewModel : INotifyPropertyChanged
{
    private readonly CartService _cartService;
    private Product _product;
    public ICommand AddToCartCommand { get; set; }
    
    public string Name
    {
        get => _product.Name;
        set
        {
            _product.Name = value;
            OnPropertyChanged();
        }
    }
    
    public string Description
    {
        get => _product.Description;
        set
        {
            _product.Description = value;
            OnPropertyChanged();
        }
    }
    
    public decimal Price
    {
        get => _product.Price;
        set
        {
            _product.Price = value;
            OnPropertyChanged();
        }
    }
    
    public ProductViewModel(CartService cartService, Product product)
    {
        _cartService = cartService;
        _product = product;
        
        AddToCartCommand = new RelayCommand(AddToCart, CanAddToCart);
    }
    
    private void AddToCart()
    {
        _cartService.AddToCart(_product);
    }
    
    private bool CanAddToCart()
    {
        return _product.Stock > 0;
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}