using HospitalManagementSystem.Application.DTOs.Room;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IRoomService
{
    Task<RoomDto?> GetRoomAsync(int roomId);
    Task<IEnumerable<RoomDto>> GetRoomsAsync();
    Task<IEnumerable<RoomDto>> GetActiveRoomsAsync();

    Task<int> CreateRoomAsync(CreateRoomDto createRoomDto);
    Task UpdateRoomAsync(UpdateRoomDto updateRoomDto);
    Task DeleteRoomAsync(int roomId);
}
