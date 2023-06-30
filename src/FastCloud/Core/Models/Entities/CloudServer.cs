namespace FastCloud.Core.Models.Entities;

public class CloudServer : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public Guid OwnerId { get; set; }

    public IEnumerable<ServerService> Services { get; set; }
}