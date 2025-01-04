using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ShoppingApp.Models;

namespace ShoppingApp.Helpers;

public static class FileHelper
{
    private const string StockFileName = "stock.json";
    
    public static List<Product> ReadStock()
    {
        if (!File.Exists(StockFileName))
        {
            return new List<Product>();;
        }
        
        var json = File.ReadAllText(StockFileName);

        var products = JsonSerializer.Deserialize<List<Product>>(json);

        return products;
    }
    
    public static void WriteStock(List<Product> products)
    {
        var json = JsonSerializer.Serialize(products);
        File.WriteAllText(StockFileName, json);
    }
}