using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CharacterTitles> CharacterTitles { get; set; }
    public DbSet<Characters> Characters { get; set; }
    public DbSet<Titles> Titles { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Backpacks> Backpacks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Characters>().HasData(new List<Characters>()
        {
            new() { Id = 1, FirstName = "John", LastName = "Doe", CurrentWeight = 10, MaxWeight = 10},
            new() { Id = 2, FirstName = "Ann", LastName = "Smith", CurrentWeight = 20, MaxWeight = 20},
            new() { Id = 3, FirstName = "Jack", LastName = "Taylor", CurrentWeight = 30, MaxWeight = 30}
        });
        modelBuilder.Entity<Items>().HasData(new List<Items>()
        {
            new() { Id = 1, Name = "Rock", Weight = 10},
            new() { Id = 2, Name = "Paper", Weight = 20},
            new() { Id = 3, Name = "Scissors", Weight = 30}
        });
        modelBuilder.Entity<Backpacks>().HasData(new List<Backpacks>()
        {
            new() { CharacterId = 1, Itemid = 1, Amount = 10},
            new() { CharacterId = 2, Itemid = 2, Amount = 20},
            new() { CharacterId = 3, Itemid = 2, Amount = 30}
        });
        modelBuilder.Entity<Titles>().HasData(new List<Titles>()
        {
            new() { Id = 1, Name = "Gold"},
            new() { Id = 2, Name = "Bronze"},
            new() { Id = 3, Name = "Silver"}
        });
        modelBuilder.Entity<CharacterTitles>().HasData(new List<CharacterTitles>()
        {
            new() { CharacterId = 1, TitleId = 1, AcquiredAt = DateTime.Today},
            new() { CharacterId = 2, TitleId = 2, AcquiredAt = DateTime.Today},
            new() { CharacterId = 3, TitleId = 3, AcquiredAt = DateTime.Today}
        });
    }
}