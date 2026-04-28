using DriveLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DriveLog.Infrastructure;

public class DriveLogDbContext(DbContextOptions options) : DbContext(options) {
    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceLap> RaceLaps { get; set; }
    public DbSet<Track> Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.EnableSensitiveDataLogging();

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}
