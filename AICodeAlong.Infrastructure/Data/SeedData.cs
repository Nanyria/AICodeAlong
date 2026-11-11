using AICodeAlong.Domain.Entities;

namespace AICodeAlong.Infrastructure.Data;

// Exempeldata så att appen har något att visa direkt.
// I kursprojektet ligger datan i en Azure SQL-databas istället.
public static class SeedData
{
    public static List<Room> Rooms() =>
    [
        new Room { Id = 1, Name = "Konferensrum Ek", Capacity = 8 },
        new Room { Id = 2, Name = "Grupprum Björk", Capacity = 4 },
        new Room { Id = 3, Name = "Studio Lind", Capacity = 12 }
    ];

    public static List<Booking> Bookings()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        return
        [
            new Booking { Id = 1, RoomId = 1, BookedBy = "Sara", Date = today.AddDays(-3), Guests = 6 },
            new Booking { Id = 2, RoomId = 2, BookedBy = "Ali", Date = today.AddDays(1), Guests = 3 },
            new Booking { Id = 3, RoomId = 3, BookedBy = "Emma", Date = today.AddDays(2), Guests = 10 },
            new Booking { Id = 4, RoomId = 1, BookedBy = "Johan", Date = today.AddDays(4), Guests = 5 },
            new Booking { Id = 5, RoomId = 2, BookedBy = "Lina", Date = today.AddDays(7), Guests = 2 }
        ];
    }
}
