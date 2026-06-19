using Microsoft.EntityFrameworkCore;

namespace Homework24
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Указываем явный путь, чтобы файл всегда брался из папки запуска приложения
            optionsBuilder.UseSqlite("Data Source=it_company.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Personal");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);

                entity.Property(e => e.Salary)
                      .HasColumnType("DECIMAL(18,2)")
                      .HasDefaultValue(0.00);

                entity.Property(e => e.HireDate)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(e => e.Position)
                      .WithMany(p => p.Employees)
                      .HasForeignKey(e => e.PositionId);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Positions");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Title).IsRequired().HasMaxLength(100);

                entity.HasData(
                    new Position { Id = 1, Title = "Developer" },
                    new Position { Id = 2, Title = "Manager" },
                    new Position { Id = 3, Title = "Tester" },
                    new Position { Id = 4, Title = "Designer" }
                );
            });
        }
    }
}