using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Journey> Journeys { get; set; }
    public DbSet<JourneyImage> JourneyImages { get; set; }

    public string DbPath { get; }

    // Constructor with DbContextOptions
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        DbPath = "ScrapBookDb.sqlite";  // Initialize DbPath here
    }

    // Override OnConfiguring to use SQLite with the DbPath
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}