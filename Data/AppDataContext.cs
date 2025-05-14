namespace zonable.Data;
using Microsoft.EntityFrameworkCore;
using zonable.Models;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    public DbSet<Models.Customer> Customers { get; set; } = null!;
    public DbSet<Models.Settings> Settings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {

            entity.HasKey(e => e.CustomerId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.ToTable("Customers");
            entity.HasData(new List<Customer>
            {
                new() {
                CustomerId = 1,
                Name = "John Doe",
                CreatedAt = DateTime.UtcNow
            },
            new() {
                CustomerId = 2,
                Name = "Jane Smith",
                CreatedAt = DateTime.UtcNow
            }
            }
            );
        });
        modelBuilder.Entity<Settings>(entity =>
        {
            entity.HasKey(e => e.SettingId);
            entity.Property(e => e.TimeZone).IsRequired();
            entity.Property(e => e.SettingId).HasDefaultValue("default");

            entity.HasData(new List<Settings>{
            new(){
                SettingId = "utc",
                TimeZone = TimeZoneInfo.Utc.Id
            },
            new(){
                SettingId = "local",
                TimeZone = TimeZoneInfo.Local.Id
            }
            }
            );

            entity.ToTable("Settings");
        });
    }
}