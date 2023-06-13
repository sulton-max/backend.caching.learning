using PowerFitness.Core.Models.Common;

namespace PowerFitness.Core.Models.Entities;
public class User : IEntity

{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserSubscription Subscription { get; set; }
}