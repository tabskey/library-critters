
namespace LibraryCritters.Models;

public class  Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Variant { get; set; }
    public string Species { get; set; }
    public CharacterRole Role { get; set; }
    public string? Description { get; set; }
    public int ReleaseYear { get; set; }
    public int? BirthDay { get; set; }
    public int? BirthMonth { get; set; }
    public string? ImageUrl { get; set; }
    public List<CharacterFamily> CharacterFamilies { get; set; } = new();
    public List<ProductItem> ProductItems { get; set; } = new();
}