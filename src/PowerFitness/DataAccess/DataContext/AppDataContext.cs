using Microsoft.EntityFrameworkCore;
using PowerFitness.Core.Models.Entities;
using PowerFitness.DataAccess.DataConfiguration;

namespace PowerFitness.DataAccess.DataContext;

public class AppDataContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<UserSubscription> UserSubscriptions => Set<UserSubscription>();

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserSubscriptionConfiguration).Assembly);
    }
}