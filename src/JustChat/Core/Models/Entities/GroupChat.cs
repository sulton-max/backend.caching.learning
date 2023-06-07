using JustChat.Core.Models.Common;

namespace JustChat.Core.Models.Entities;

public class GroupChat : IEntity
{
    public GroupChat()
    {
        Announcements = new List<GroupAnnouncement>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
    public IEnumerable<GroupAnnouncement> Announcements { get; set; }
}