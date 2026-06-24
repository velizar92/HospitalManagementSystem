using HospitalManagementSystem.Domain.Enums;

namespace HospitalManagementSystem.Application.Queries;

public class DoctorQuery
{
    public int? DepartmentId { get; set; }
    public AppointmentStatus? AppointmentStatus { get; set; }
    public string? OrderBy { get; set; } 
    public bool Desc { get; set; } = false;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
