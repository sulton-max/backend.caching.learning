using UniBlog.Core.Models.Common;

namespace UniBlog.Core.Models.Entity;

public class User : IEntity
{
    public User()
    {
        Posts = new List<BlogPost>();
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public IEnumerable<BlogPost> Posts { get; set; }
}