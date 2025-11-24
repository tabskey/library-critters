using LibraryCritters.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryCritters;

public class LibraryContextFactory : IDesignTimeDbContextFactory<SylvanianContext> 
{
    public SylvanianContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            
        var optionsBuilder = new DbContextOptionsBuilder<SylvanianContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        optionsBuilder.UseSqlServer(connectionString);
        
        return new SylvanianContext(optionsBuilder.Options);
    }
}