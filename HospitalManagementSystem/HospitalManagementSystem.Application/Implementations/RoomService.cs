using HospitalManagementSystem.Application.DTOs.Room;
using HospitalManagementSystem.Application.Interfaces;

namespace HospitalManagementSystem.Application.Implementations;

public class RoomService : IRoomService
{
    public Task<int> CreateRoomAsync(CreateRoomDto createRoomDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRoomAsync(int roomId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RoomDto>> GetActiveRoomsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<RoomDto?> GetRoomAsync(int roomId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RoomDto>> GetRoomsAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateRoomAsync(UpdateRoomDto updateRoomDto)
    {
        throw new NotImplementedException();
    }
}
