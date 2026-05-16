using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Room;

public class CreateRoomDto
{
    [Required]
    public string RoomNumber { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int Capacity { get; set; }

    public string Purpose { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}
