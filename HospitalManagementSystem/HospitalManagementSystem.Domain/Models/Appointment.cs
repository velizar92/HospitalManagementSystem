using HospitalManagementSystem.Domain.Enums;

namespace HospitalManagementSystem.Domain.Models;

public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public AppointmentStatus Status { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public int? MedicalRecordId { get; set; }
    public MedicalRecord? MedicalRecord { get; set; }
}
