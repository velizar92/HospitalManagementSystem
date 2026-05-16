namespace HospitalManagementSystem.Application.DTOs.Room;

public class RoomDto
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string Purpose { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
