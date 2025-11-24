namespace LibraryCritters.Models;

public class CharacterFamily
{
    public int CharacterId { get; set; }
    public Character Character { get; set; }
    
    public int FamilyId { get; set; }
    public Family Family { get; set; }
    
    public string Relationship { get; set; }
    public int JoinYear { get; set; }
}