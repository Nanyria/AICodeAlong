namespace AICodeAlong.Domain.Entities;

// En bokning av ett rum en viss dag.
public class Booking
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string BookedBy { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public int Guests { get; set; }
}
