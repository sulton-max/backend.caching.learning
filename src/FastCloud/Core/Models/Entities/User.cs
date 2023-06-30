namespace FastCloud.Core.Models.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public IEnumerable<CloudServer> Servers { get; set; }
}