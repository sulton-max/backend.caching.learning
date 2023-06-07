using EasyTicket.DataAccess.DataConfiguration;
using EasyTicket.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyTicket.DataAccess.DataContext;

public class AppDataContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Ticket> Tickets => Set<Ticket>();

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketEntityConfiguration).Assembly);
    }
}