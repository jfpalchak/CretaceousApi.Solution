using Microsoft.EntityFrameworkCore;

namespace CretaceousApi.Models;

public class CretaceousApiContext : DbContext
{
  public DbSet<Animal> Animals { get; set; }

  public CretaceousApiContext(DbContextOptions<CretaceousApiContext> options) : base(options) { }
}