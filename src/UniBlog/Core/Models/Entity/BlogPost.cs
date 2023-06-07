using UniBlog.Core.Models.Common;

namespace UniBlog.Core.Models.Entity;

public class BlogPost : IEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public Guid AuthorId { get; set; }
}