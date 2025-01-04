using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ShoppingApp.Models;
using ShoppingApp.Services;

namespace ShoppingApp.ViewModels;

public class MainViewModel
{
    public ObservableCollection<CartItem> CartItems { get; set; }
    private readonly CartService _cartService;
    
    public ICommand PopupOpenCommand { get; }
    
    public MainViewModel(CartService cartService)
    {
        _cartService = cartService;
        CartItems = new ObservableCollection<CartItem>();
        
        PopupOpenCommand = new RelayCommand(OpenPopup, () => true);
    }
    
    private void OpenPopup()
    {
        // Podczas otwierania okna, pobierz produkty.
        var items = _cartService.GetCartItems();
        
        CartItems.Clear();
        
        foreach (var item in items)
        {
            CartItems.Add(item);
        }
    }
}