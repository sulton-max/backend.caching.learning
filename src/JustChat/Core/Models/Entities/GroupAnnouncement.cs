using JustChat.Core.Models.Common;

namespace JustChat.Core.Models.Entities;

public class GroupAnnouncement : IEntity
{
    public Guid Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTimeOffset SentTime { get; set; }
    public DateTimeOffset EditedTime { get; set; }
    public Guid GroupId { get; set; }
}