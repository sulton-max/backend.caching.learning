using Microsoft.EntityFrameworkCore;
using UniBlog.Core.Models.Entity;
using UniBlog.DataAccess.DataConfiguration;

namespace UniBlog.DataAccess.DataContext;

public class AppDataContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<BlogPost> Posts => Set<BlogPost>();
    
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogPostConfiguration).Assembly);
    }
}