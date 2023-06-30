using FastCloud.Core.Models.Entities;
using FastCloud.DataAccess.DataConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FastCloud.DataAccess.DataContexts;

public class AppDataContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<CloudServer> Servers => Set<CloudServer>();
    public DbSet<CloudService> Services => Set<CloudService>();
    public DbSet<ServerService> ServerServices => Set<ServerService>();

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServerServiceConfiguration).Assembly);
    }
}