namespace LibraryCritters.Models;

public class Accessory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // "Kitchen", "Furniture", "House", "Vehicle"
    public string Description { get; set; }
    public List<string> Tags { get; set; } = new();
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
}