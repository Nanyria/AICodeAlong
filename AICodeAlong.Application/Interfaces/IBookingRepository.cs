using AICodeAlong.Domain.Entities;

namespace AICodeAlong.Application.Interfaces;

public interface IBookingRepository
{
    IReadOnlyList<Booking> GetAll();
    void Add(Booking booking);
}
