using AICodeAlong.Application.Interfaces;
using AICodeAlong.Domain.Entities;
using AICodeAlong.Infrastructure.Data;

namespace AICodeAlong.Infrastructure.Repositories;

// Sparar bokningarna i minnet. Allt nollställs när appen startas om.
public class InMemoryBookingRepository : IBookingRepository
{
    private readonly List<Booking> _bookings = SeedData.Bookings();

    public IReadOnlyList<Booking> GetAll()
    {
        return _bookings;
    }

    public void Add(Booking booking)
    {
        booking.Id = _bookings.Count == 0 ? 1 : _bookings.Max(b => b.Id) + 1;
        _bookings.Add(booking);
    }

    public bool Remove(int bookingId)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking is null)
        {
            return false;
        }

        _bookings.Remove(booking);
        return true;
    }
}
