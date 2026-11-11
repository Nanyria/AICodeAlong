using AICodeAlong.Application.Interfaces;
using AICodeAlong.Domain.Entities;

namespace AICodeAlong.Tests;

// Enkla låtsas-repositories så att testerna inte beror på infrastrukturlagret.
public class FakeRoomRepository : IRoomRepository
{
    private readonly List<Room> _rooms;

    public FakeRoomRepository(params Room[] rooms)
    {
        _rooms = rooms.ToList();
    }

    public IReadOnlyList<Room> GetAll() => _rooms;

    public Room? GetById(int id) => _rooms.FirstOrDefault(r => r.Id == id);
}

public class FakeBookingRepository : IBookingRepository
{
    public List<Booking> Bookings { get; } = [];

    public IReadOnlyList<Booking> GetAll() => Bookings;

    public void Add(Booking booking)
    {
        booking.Id = Bookings.Count + 1;
        Bookings.Add(booking);
    }
}
