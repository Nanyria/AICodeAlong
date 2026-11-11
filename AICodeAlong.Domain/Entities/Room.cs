namespace AICodeAlong.Domain.Entities;

// Ett rum som går att boka.
public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Max antal personer som får plats i rummet.
    public int Capacity { get; set; }
}
