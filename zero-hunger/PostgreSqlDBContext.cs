namespace zero_hunger;

using Models;

using Microsoft.EntityFrameworkCore;
using zero_hunger.Models.Helper;

public class PostgreSqlDBContext : DbContext
{
    public DbSet<User> User { get; set; } = null!;
    public DbSet<Restaurant> Restaurant { get; set; } = null!;
    public DbSet<CollectRequest> CollectRequest { get; set; } = null!;
    public PostgreSqlDBContext(DbContextOptions<PostgreSqlDBContext> options) : base(options) { }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow;

            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedAt = now;
            }
            ((BaseEntity)entity.Entity).UpdatedAt = now;
        }
    }
}