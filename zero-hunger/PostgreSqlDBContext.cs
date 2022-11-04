namespace zero_hunger;

using Models;

using Microsoft.EntityFrameworkCore;

public class PostgreSqlDBContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Restaurant> Restaurant { get; set; }
    public PostgreSqlDBContext(DbContextOptions<PostgreSqlDBContext> options) : base(options) { }
}