using System;
using System.Collections.Generic;
using ShoppingApp.Helpers;
using ShoppingApp.Models;

namespace ShoppingApp.Services;

public class ProductRepository : IDisposable
{
    private List<Product> _products;
    private bool _disposed = false;

    public ProductRepository()
    {
        _products = new StockService().GenerateStockIfEmpty();
    }
    
    public Product GetProductByName(string name)
    {
        return _products.Find(p => p.Name == name);
    }
    
    public List<Product> GetProducts()
    {
        return _products;
    }
    
    public List<Product> GetProductsByCategory(ProductCategory category)
    {
        return _products.FindAll(p => p.Category == category);
    }
    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    
    public void UpdateProduct(Product product)
    {
        var index = _products.FindIndex(p => p.Name == product.Name);
        _products[index] = product;
    }
    
    public void DeleteProduct(string name)
    {
        _products.RemoveAll(p => p.Name == name);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                FileHelper.WriteStock(_products);
            }
            _disposed = true;
        }
    }
}