using AICodeAlong.Application.Interfaces;
using AICodeAlong.Domain.Entities;

namespace AICodeAlong.Application.Services;

public class RoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public IReadOnlyList<Room> GetAll()
    {
        return _roomRepository.GetAll()
            .OrderBy(r => r.Name)
            .ToList();
    }
}
