namespace FastCloud.Core.Models.Entities;

public class ServerService : IEntity
{
    public Guid Id { get; set; }
    public Guid ServerId { get; set; }
    public Guid ServiceId { get; set; }
}