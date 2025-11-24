using Microsoft.EntityFrameworkCore;

namespace LibraryCritters.Models.Data;

public class SylvanianContext : DbContext
{
    public SylvanianContext(DbContextOptions<SylvanianContext> options) : base(options) { }

    // DbSets
    public DbSet<Character> Characters { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<Accessory> Accessories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CharacterFamily> CharacterFamilies { get; set; }
    public DbSet<ProductItem> ProductItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // CharacterFamily - (N:N)
        modelBuilder.Entity<CharacterFamily>()
            .HasKey(cf => new { cf.CharacterId, cf.FamilyId });
            
        modelBuilder.Entity<CharacterFamily>()
            .HasOne(cf => cf.Character)
            .WithMany(c => c.CharacterFamilies)
            .HasForeignKey(cf => cf.CharacterId);
            
        modelBuilder.Entity<CharacterFamily>()
            .HasOne(cf => cf.Family)
            .WithMany(f => f.CharacterFamilies)
            .HasForeignKey(cf => cf.FamilyId);
        
        modelBuilder.Entity<ProductItem>()
            .HasOne(pv => pv.Product)
            .WithMany(p => p.Variants)
            .HasForeignKey(pv => pv.ProductId);
        
        modelBuilder.Entity<Accessory>()
            .Property(a => a.Tags)
            .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
            );
    }
}