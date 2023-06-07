using EasyTicket.Models.Common;

namespace EasyTicket.Models.Entities;

public class User : IEntity
{
    public User()
    {
        Tickets = new List<Ticket>();
    }

    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Address { get; set; }
    public IEnumerable<Ticket> Tickets { get; set; }
}