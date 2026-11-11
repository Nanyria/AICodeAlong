using AICodeAlong.Domain.Entities;

namespace AICodeAlong.Application.Interfaces;

// Applikationslagret bestämmer vad det behöver.
// Infrastrukturlagret bestämmer hur det görs.
public interface IRoomRepository
{
    IReadOnlyList<Room> GetAll();
    Room? GetById(int id);
}
