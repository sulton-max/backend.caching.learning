using JustChat.Core.Models.Entities;
using JustChat.DataAccess.DataConfiguration;
using Microsoft.EntityFrameworkCore;

namespace JustChat.DataAccess.DataContext;

public class AppDataContext : DbContext
{
    public DbSet<GroupChat> Groups => Set<GroupChat>();
    public DbSet<GroupAnnouncement> Announcements => Set<GroupAnnouncement>();

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatAnnouncementConfiguration).Assembly);
    }
}