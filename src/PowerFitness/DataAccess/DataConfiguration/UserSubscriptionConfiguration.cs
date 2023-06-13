using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerFitness.Core.Models.Entities;

namespace PowerFitness.DataAccess.DataConfiguration;

public class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
{
    public void Configure(EntityTypeBuilder<UserSubscription> builder)
    {
        builder.HasOne<User>().WithOne(x => x.Subscription).HasForeignKey<User>();
        builder.HasOne<Subscription>().WithMany(x => x.Subscriptions).HasForeignKey(x => x.SubscriptionId);
    }
}