using Microsoft.EntityFrameworkCore;
using PropertEase_Models.Models.Core;

namespace PropertEase_Database.SQLConnection;

public class PropertEaseDbContext : DbContext
{
    public DbSet<Property> Properties { get; set; }
    public PropertEaseDbContext(DbContextOptions<PropertEaseDbContext> options) : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
}
