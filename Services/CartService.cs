using System.Collections.Generic;
using System.Linq;
using ShoppingApp.Models;

namespace ShoppingApp.Services;

public class CartService
{
    private readonly List<CartItem> _cartItems = new List<CartItem>();
    
    public void AddToCart(Product product)
    {
        var cartItem = _cartItems.FirstOrDefault(x => x.Product.Name == product.Name);
        
        if (cartItem == null)
        {
            _cartItems.Add(new CartItem
            {
                Product = product,
                Quantity = 1
            });
        }
        else
        {
            cartItem.Quantity++;
        }
        
        product.Stock--;
    }
    
    public void RemoveFromCart(Product product)
    {
        var cartItem = _cartItems.FirstOrDefault(x => x.Product.Name == product.Name);
        
        if (cartItem == null)
        {
            return;
        }
        
        cartItem.Quantity--;
        
        if (cartItem.Quantity == 0)
        {
            _cartItems.Remove(cartItem);
        }
        
        product.Stock++;
    }
    
    public List<CartItem> GetCartItems()
    {
        return _cartItems;
    }
    
    public void ClearCart()
    {
        _cartItems.Clear();
    }
}