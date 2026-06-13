using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Homework24;
public class CompanyContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=it_company.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Personal"); 

            entity.HasKey(e => e.Id);

            entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(50); 

            entity.Property(e => e.Position)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Salary)
                  .HasColumnType("DECIMAL(18,2)")
                  .HasDefaultValue(0.00);

            entity.Property(e => e.HireDate)
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}