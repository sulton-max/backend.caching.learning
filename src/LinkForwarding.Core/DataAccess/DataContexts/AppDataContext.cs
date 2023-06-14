using LinkForwarding.Core.Core.Models.Entities;
using LinkForwarding.Core.DataAccess.DataConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LinkForwarding.Core.DataAccess.DataContexts;

public class AppDataContext : DbContext
{
    public DbSet<Link> Links => Set<Link>();
    public DbSet<LinkPolicy> LinkPolicies => Set<LinkPolicy>();

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LinkPolicyConfiguration).Assembly);
    }
}