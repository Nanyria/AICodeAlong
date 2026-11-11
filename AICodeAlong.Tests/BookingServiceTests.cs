using AICodeAlong.Application.Services;
using AICodeAlong.Domain.Entities;

namespace AICodeAlong.Tests;

public class BookingServiceTests
{
    private static readonly DateOnly Tomorrow = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

    [Fact]
    public void Create_TooManyGuests_ReturnsError()
    {
        // Arrange
        var rooms = new FakeRoomRepository(new Room { Id = 1, Name = "Grupprum Björk", Capacity = 4 });
        var bookings = new FakeBookingRepository();
        var service = new BookingService(bookings, rooms);

        var booking = new Booking { RoomId = 1, BookedBy = "Sara", Date = Tomorrow, Guests = 5 };

        // Act
        var result = service.Create(booking);

        // Assert
        Assert.False(result.Success);
        Assert.Empty(bookings.Bookings);
    }
}
