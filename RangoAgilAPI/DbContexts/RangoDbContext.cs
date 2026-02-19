using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RangoAgilAPI.Entities;

namespace RangoAgilAPI.DbContexts;
public class RangoDbContext(DbContextOptions<RangoDbContext> options) : DbContext(options) {
    public DbSet<Rango> Rangos { get; set; } = null;
    public DbSet<Ingrediente> Ingredientes { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
    }
}

