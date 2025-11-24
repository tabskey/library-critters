namespace LibraryCritters.Models;

public class Product
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public ProductType Type { get; set; }
    public string ProductNumber { get; set; }
    public string Description { get; set; }
    public string Distribuitor { get; set; }

    public int ReleaseYear { get; set; }
    public List<string> ItemCode { get; set; } = new();
    public string MainImageUrl { get; set; }
    public List<ProductItem> Variants { get; set; } = new();
}