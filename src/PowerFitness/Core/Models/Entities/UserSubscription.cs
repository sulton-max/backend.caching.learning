using PowerFitness.Core.Models.Common;

namespace PowerFitness.Core.Models.Entities;

public class UserSubscription : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SubscriptionId { get; set; }
    public DateTime SubscribedDate { get; set; }
}