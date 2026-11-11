using AICodeAlong.Application.Interfaces;
using AICodeAlong.Domain.Entities;

namespace AICodeAlong.Application.Services;

public class BookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomRepository _roomRepository;

    public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
    }

    // Alla bokningar från och med idag, sorterade på datum.
    // Skicka med ett roomId för att bara få bokningarna för det rummet.
    public IReadOnlyList<BookingOverview> GetUpcoming(int? roomId = null)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        return _bookingRepository.GetAll()
            .Where(b => b.Date >= today)
            .Where(b => roomId == null || b.RoomId == roomId)
            .OrderBy(b => b.Date)
            .Select(ToOverview)
            .ToList();
    }

    public BookingResult Create(Booking booking)
    {
        if (string.IsNullOrWhiteSpace(booking.BookedBy))
        {
            return BookingResult.Fail("Ange vem som bokar.");
        }

        if (booking.Guests < 1)
        {
            return BookingResult.Fail("Antal personer måste vara minst 1.");
        }

        var room = _roomRepository.GetById(booking.RoomId);

        // Kontrollera att rummet finns innan vi använder det.
        if (room is null)
        {
            return BookingResult.Fail("Rummet finns inte.");
        }

        if (booking.Guests > room.Capacity)
        {
            return BookingResult.Fail($"{room.Name} har bara plats för {room.Capacity} personer.");
        }

        if (booking.Date < DateOnly.FromDateTime(DateTime.Today))
        {
            return BookingResult.Fail("Du kan inte boka ett datum som redan har varit.");
        }

        var alreadyBooked = _bookingRepository.GetAll()
            .Any(b => b.Date == booking.Date);

        if (alreadyBooked)
        {
            return BookingResult.Fail($"{room.Name} är redan bokat {booking.Date}.");
        }

        _bookingRepository.Add(booking);
        return BookingResult.Ok();
    }

    private BookingOverview ToOverview(Booking booking)
    {
        var roomName = _roomRepository.GetById(booking.RoomId)?.Name ?? "Okänt rum";

        return new BookingOverview(
            booking.Id,
            booking.RoomId,
            roomName,
            booking.BookedBy,
            booking.Date,
            booking.Guests);
    }
}
