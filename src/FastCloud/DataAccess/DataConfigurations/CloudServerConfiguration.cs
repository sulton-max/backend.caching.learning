using FastCloud.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastCloud.DataAccess.DataConfigurations;

public class CloudServerConfiguration : IEntityTypeConfiguration<CloudServer>
{
    public void Configure(EntityTypeBuilder<CloudServer> builder)
    {
        builder.HasOne<User>().WithMany(x => x.Servers).HasForeignKey(x => x.OwnerId);
    }
}