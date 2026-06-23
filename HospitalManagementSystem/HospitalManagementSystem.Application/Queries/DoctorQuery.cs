using HospitalManagementSystem.Domain.Enums;

namespace HospitalManagementSystem.Application.Queries;

public class DoctorQuery
{
    public int? DepartmentId { get; set; }
    public AppointmentStatus? AppointmentStatus { get; set; }
}
