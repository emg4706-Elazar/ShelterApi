using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;

namespace ShelterApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        :base(options)
    {
    }

    public DbSet<Area> Areas { get; set; } = null!;
    public DbSet<Shelter> Shelters { get; set; } = null!;
    public DbSet<Inspection> Inspections { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Shelter>()
            .HasOne(s => s.Area)
            .WithMany(a => a.Shelters)
            .HasForeignKey(s => s.AreaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Inspection>()
            .HasOne(i => i.Shelter)
            .WithMany(s => s.Inspections)
            .HasForeignKey(i => i.ShelterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
