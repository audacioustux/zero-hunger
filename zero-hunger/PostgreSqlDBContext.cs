using Microsoft.EntityFrameworkCore;
namespace zero_hunger;
public class PostgreSqlDBContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Job> Job { get; set; }
    public PostgreSqlDBContext(DbContextOptions<PostgreSqlDBContext> options) : base(options) { }
}