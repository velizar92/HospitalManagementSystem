using HospitalManagementSystem.Application.DTOs.Room;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Implementations;

public class RoomService : IRoomService
{
    private readonly HospitalManagementSystemDbContext _dbContext;

    public RoomService(HospitalManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateRoomAsync(CreateRoomDto createRoomDto)
    {
        var room = new Room
        {
            RoomNumber = createRoomDto.RoomNumber,
            IsActive = createRoomDto.IsActive,
            Capacity = createRoomDto.Capacity,
            Purpose = createRoomDto.Purpose
        };

        _dbContext.Rooms.Add(room);
        await _dbContext.SaveChangesAsync();

        return room.Id;
    }

    public async Task<IEnumerable<RoomDto>> GetActiveRoomsAsync()
    {
        return await _dbContext.Rooms
            .Where(r => r.IsActive)
            .Select(r => new RoomDto
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                Capacity = r.Capacity,
                Purpose = r.Purpose,
                IsActive = r.IsActive
            })
            .ToListAsync();
    }

    public async Task<RoomDto?> GetRoomAsync(int roomId)
    {
        return await _dbContext.Rooms
            .Where(r => r.Id == roomId)
            .Select(r => new RoomDto
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                Capacity = r.Capacity,
                Purpose = r.Purpose,
                IsActive = r.IsActive
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<RoomDto>> GetRoomsAsync()
    {
        return await _dbContext.Rooms
            .Select(r => new RoomDto
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                Capacity = r.Capacity,
                Purpose = r.Purpose,
                IsActive = r.IsActive
            })
            .ToListAsync();
    }

    public Task UpdateRoomAsync(UpdateRoomDto updateRoomDto)
    {
        if (updateRoomDto == null)
        {
            throw new ArgumentNullException(nameof(updateRoomDto));
        }

        var room = _dbContext.Rooms.FirstOrDefault(r => r.Id == updateRoomDto.Id);

        if (room == null)
        {
            throw new Exception("Room not found");
        }

        room.RoomNumber = updateRoomDto.RoomNumber;
        room.Capacity = updateRoomDto.Capacity;
        room.Purpose = updateRoomDto.Purpose;
        room.IsActive = updateRoomDto.IsActive;

        return _dbContext.SaveChangesAsync();
    }

    public Task DeleteRoomAsync(int roomId)
    {
        if (roomId <= 0)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

        var room = _dbContext.Rooms.FirstOrDefault(r => r.Id == roomId);

        if (room == null)
        {
            throw new Exception("Room not found");
        }

        _dbContext.Rooms.Remove(room);
        return _dbContext.SaveChangesAsync();
    }
}
