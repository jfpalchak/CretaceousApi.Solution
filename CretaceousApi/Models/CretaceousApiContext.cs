using Microsoft.EntityFrameworkCore;

namespace CretaceousApi.Models;

public class CretaceousApiContext : DbContext
{
  public DbSet<Animal> Animals { get; set; }

  public CretaceousApiContext(DbContextOptions<CretaceousApiContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Animal>()
      .HasData(
        new Animal { AnimalId = 1, Name = "Matilda", Species = "Woolly Mammoth", Age = 7 },
        new Animal { AnimalId = 2, Name = "Rexie", Species = "Dinosaur", Age = 10 },
        new Animal { AnimalId = 3, Name = "Matilda", Species = "Dinosaur", Age = 2 },
        new Animal { AnimalId = 4, Name = "Pip", Species = "Shark", Age = 4 },
        new Animal { AnimalId = 5, Name = "Bartholomew", Species = "Dinosaur", Age = 22 } 
      );
  }
}