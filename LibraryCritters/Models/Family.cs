namespace LibraryCritters.Models;

public class Family
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public string Description { get; set; }
    public int ReleaseYear { get; set; }
    public string CountryOfOrigin { get; set; }
    public string FamilyImageUrl { get; set; }
    public List<CharacterFamily> CharacterFamilies { get; set; } = new();
    public List<Product> Products { get; set; } = new();
}