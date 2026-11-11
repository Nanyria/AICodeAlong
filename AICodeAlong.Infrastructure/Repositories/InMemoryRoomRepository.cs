using AICodeAlong.Application.Interfaces;
using AICodeAlong.Domain.Entities;
using AICodeAlong.Infrastructure.Data;

namespace AICodeAlong.Infrastructure.Repositories;

// Sparar rummen i minnet. Allt nollställs när appen startas om.
public class InMemoryRoomRepository : IRoomRepository
{
    private readonly List<Room> _rooms = SeedData.Rooms();

    public IReadOnlyList<Room> GetAll()
    {
        return _rooms;
    }

    public Room? GetById(int id)
    {
        return _rooms.FirstOrDefault(r => r.Id == id);
    }
}
