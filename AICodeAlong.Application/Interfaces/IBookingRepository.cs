using AICodeAlong.Domain.Entities;

namespace AICodeAlong.Application.Interfaces;

public interface IBookingRepository
{
    IReadOnlyList<Booking> GetAll();
    void Add(Booking booking);

    // Tar bort bokningen. Returnerar false om den inte fanns.
    bool Remove(int bookingId);
}
