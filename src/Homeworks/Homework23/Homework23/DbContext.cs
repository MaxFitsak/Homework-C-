using Microsoft.EntityFrameworkCore;
using Moedls;
namespace DataBaseContext;

public class warehouse : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supllier> Suplliers { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=Warehouse.db");
        }
    }
}
