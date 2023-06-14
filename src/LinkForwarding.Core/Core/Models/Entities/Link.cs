namespace LinkForwarding.Core.Core.Models.Entities;

public class Link : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string ShortenedLink { get; set; } = string.Empty;
    public string ActualLink { get; set; } = string.Empty;
    public Guid PolicyId { get; set; }
    public LinkPolicy LinkPolicy { get; set; }
}