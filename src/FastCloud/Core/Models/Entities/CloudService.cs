namespace FastCloud.Core.Models.Entities;

public class CloudService : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsBackground { get; set; }
    public IEnumerable<ServerService> Servers { get; set; }
}