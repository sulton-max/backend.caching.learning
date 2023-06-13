using PowerFitness.Core.Models.Common;

namespace PowerFitness.Core.Models.Entities;

public class Subscription : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MonthlyFee { get; set; }
    public IEnumerable<UserSubscription> Subscriptions { get; set; }
}