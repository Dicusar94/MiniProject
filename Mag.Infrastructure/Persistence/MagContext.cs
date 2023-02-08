using System.Collections.Immutable;
using Mag.Domain.ProductAggregate.Entities;
using Mag.Infrastructure.Common.Marker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mag.Infrastructure.Persistence;

public class MagContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;

    public MagContext (DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BaseConfiguration(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    private static void BaseConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Model.GetEntityTypes()
        .SelectMany(e => e.GetProperties())
        .Where(p => p.IsPrimaryKey())
        .ToList()
        .ForEach(p => p.ValueGenerated = ValueGenerated.Never);
    }
}