namespace HospitalManagementSystem.Domain.Models;

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; }   
    public int Capacity { get; set; }        
    public string Purpose { get; set; }     
    public bool IsActive { get; set; } = true;
    public ICollection<Admission> Admissions { get; set; } = [];
}
