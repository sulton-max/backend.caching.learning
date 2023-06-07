using EasyTicket.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyTicket.DataAccess.DataConfiguration;

internal class TicketEntityConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasOne<User>().WithMany(x => x.Tickets).HasForeignKey(x => x.UserId);
    }
}