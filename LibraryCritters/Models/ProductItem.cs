namespace LibraryCritters.Models;

public class ProductItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int? CharacterId { get; set; }
    public Character? Character { get; set; }
    
    public int? FamilyId { get; set; }
    public Family? Family { get; set; }
    
    public int? AccessoryId { get; set; }
    public Accessory? Accessory { get; set; }
    
    public string Description { get; set; }
    public int Quantity { get; set; } = 1;
}