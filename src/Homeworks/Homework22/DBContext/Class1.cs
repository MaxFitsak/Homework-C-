using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

public class ApplicationContext : DbContext
{
    public DbSet<Country> Countries { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=countries.db");
    }
}
