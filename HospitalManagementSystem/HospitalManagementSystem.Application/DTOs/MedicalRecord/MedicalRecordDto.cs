namespace HospitalManagementSystem.Application.DTOs.MedicalRecord;

public class MedicalRecordDto
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int? DoctorId { get; set; }

    public string Diagnosis { get; set; } = string.Empty;

    public string Symptoms { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public string TreatmentPlan { get; set; } = string.Empty;

    public string Allergies { get; set; } = string.Empty;

    public string ChronicConditions { get; set; } = string.Empty;

    public string TestResults { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public int? AppointmentId { get; set; }

    public string? PatientFullName { get; set; }
    public string? DoctorFullName { get; set; }
    public DateTime? AppointmentDate { get; set; }
}
