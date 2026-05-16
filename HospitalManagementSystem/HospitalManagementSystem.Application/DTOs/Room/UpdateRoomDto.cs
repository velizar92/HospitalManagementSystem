using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Room;

public class UpdateRoomDto
{
    [Required]
    public int Id { get; set; }

    public string? RoomNumber { get; set; }
    public int? Capacity { get; set; }
    public string? Purpose { get; set; }
    public bool? IsActive { get; set; }
}
