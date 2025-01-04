using System.Collections.Generic;
using ShoppingApp.Helpers;
using ShoppingApp.Models;

namespace ShoppingApp.Services;

public class StockService
{
    public List<Product> GenerateStockIfEmpty()
    {
        var items = FileHelper.ReadStock();

        if (items.Count == 0)
        {
            // Generowanie przykładowych produktów.
            // Można rozszerzyć tę funkcję o generowanie większej ilości produktów.
            items.Add(new Product
            {
                Name = "Mleko",
                Description = "Mleko UHT 2%",
                Price = 3.99m,
                Stock = 100,
                Category = ProductCategory.Food
            });
            
            items.Add(new Product
            {
                Name = "Chleb",
                Description = "Chleb pszenno-żytni",
                Price = 4.49m,
                Stock = 20,
                Category = ProductCategory.Food
            });

            items.Add(new Product
            {
                Name = "Masło",
                Description = "Masło ekstra 83%",
                Price = 7.99m,
                Stock = 50,
                Category = ProductCategory.Food
            });
            
            items.Add(new Product()
            {
                Name="Mąka",
                Description="Mąka pszenna typ 500",
                Price=2.29m,
                Stock=80,
                Category=ProductCategory.Food
            });
            
            items.Add(new Product()
            {
                Name="Krzesło składane",
                Description="Krzesło składane z tworzywa sztucznego, czarne",
                Price=49.99m,
                Stock=10,
                Category=ProductCategory.Home
            });
            
            // Zapisanie listy produktów do pliku.
            FileHelper.WriteStock(items);
        }
        
        return items;
    }
}