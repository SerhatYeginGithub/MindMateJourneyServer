using GenericRepository;
using Microsoft.EntityFrameworkCore;
using MindMateJourney.Domain.Abstraction;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Context;

public sealed class AppDbContext : DbContext, IUnitOfWork
{
    public DbSet<Content> Contents { get; set; }
    public DbSet<Category> Categories { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Entity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                entry.Property(p => p.CreatedAt)
                       .CurrentValue = DateTime.Now;
            if (entry.State == EntityState.Modified)
                entry.Property(p => p.UpdatedAt)
                    .CurrentValue = DateTime.Now;
            entry.Property(p => p.CreatedAt).IsModified = false;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
