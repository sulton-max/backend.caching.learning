namespace LinkForwarding.Core.Core.Models.Entities;

public class LinkPolicy : IEntity
{
    public Guid Id { get; set; }
    public bool IsShareable { get; set; }
    public TimeSpan ExpireTime { get; set; }
    public IEnumerable<Link> Links { get; set; }
}