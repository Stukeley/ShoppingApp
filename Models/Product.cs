namespace ShoppingApp.Models;

public enum ProductCategory
{
    Food,
    Electronics,
    Clothing,
    Books,
    Home,
    Other
}

public class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public ProductCategory Category { get; set; }
    public int Stock { get; set; }
}