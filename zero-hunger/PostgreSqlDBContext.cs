namespace zero_hunger;

using Models;

using Microsoft.EntityFrameworkCore;

public class PostgreSqlDBContext : DbContext
{
    public DbSet<User> User { get; set; } = null!;
    public DbSet<Restaurant> Restaurant { get; set; } = null!;
    public DbSet<CollectRequest> CollectRequest { get; set; } = null!;
    public PostgreSqlDBContext(DbContextOptions<PostgreSqlDBContext> options) : base(options) { }
}