using LinkForwarding.Core.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkForwarding.Core.DataAccess.DataConfigurations;

public class LinkPolicyConfiguration : IEntityTypeConfiguration<LinkPolicy>
{
    public void Configure(EntityTypeBuilder<LinkPolicy> builder)
    {
        builder.HasMany<Link>().WithOne(x => x.LinkPolicy).HasForeignKey(x => x.PolicyId);
    }
}