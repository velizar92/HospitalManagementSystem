namespace HospitalManagementSystem.Application.DTOs.Prescription;

public class PrescriptionItemDto
{
    public int Id { get; set; }
    public string MedicationName { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
    public int DurationDays { get; set; }
    public string Instructions { get; set; } = string.Empty;
}
