using EasyTicket.Models.Common;

namespace EasyTicket.Models.Entities;

public class Ticket : IEntity
{
    public Guid Id { get; set; }
    public string Location { get; set; } = default!;
    public string Destination { get; set; } = default!;
    public DateTimeOffset DepartureTime { get; set; }
    public Guid UserId { get; set; }
}