using FastCloud.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastCloud.DataAccess.DataConfigurations;

public class ServerServiceConfiguration : IEntityTypeConfiguration<ServerService>
{
    public void Configure(EntityTypeBuilder<ServerService> builder)
    {
        builder.HasOne<CloudServer>().WithMany(x => x.Services).HasForeignKey(x => x.ServerId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne<CloudService>().WithMany(x => x.Servers).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.NoAction);
    }
}