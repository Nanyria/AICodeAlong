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

    [Fact]
    public void Create_RoomDoesNotExist_ReturnsError()
    {
        // Arrange
        var rooms = new FakeRoomRepository(new Room { Id = 1, Name = "Grupprum Björk", Capacity = 4 });
        var bookings = new FakeBookingRepository();
        var service = new BookingService(bookings, rooms);

        var booking = new Booking { RoomId = 0, BookedBy = "Sara", Date = Tomorrow, Guests = 2 };

        // Act
        var result = service.Create(booking);

        // Assert
        Assert.False(result.Success);
        Assert.Equal("Rummet finns inte.", result.ErrorMessage);
    }

    [Fact]
    public void Cancel_ExistingBooking_RemovesIt()
    {
        // Arrange
        var rooms = new FakeRoomRepository(new Room { Id = 1, Name = "Grupprum Björk", Capacity = 4 });
        var bookings = new FakeBookingRepository();
        var service = new BookingService(bookings, rooms);
        service.Create(new Booking { RoomId = 1, BookedBy = "Sara", Date = Tomorrow, Guests = 2 });
        var bookingId = bookings.Bookings[0].Id;

        // Act
        var cancelled = service.Cancel(bookingId);

        // Assert
        Assert.True(cancelled);
        Assert.Empty(bookings.Bookings);
    }

    [Fact]
    public void Cancel_BookingDoesNotExist_ReturnsFalse()
    {
        // Arrange
        var rooms = new FakeRoomRepository();
        var bookings = new FakeBookingRepository();
        var service = new BookingService(bookings, rooms);

        // Act
        var cancelled = service.Cancel(99);

        // Assert
        Assert.False(cancelled);
    }
}
