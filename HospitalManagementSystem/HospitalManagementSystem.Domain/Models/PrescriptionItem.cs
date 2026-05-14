namespace HospitalManagementSystem.Domain.Models;

public class PrescriptionItem
{
    public int Id { get; set; }
    public int PrescriptionId { get; set; }
    public Prescription Prescription { get; set; }
    public string MedicationName { get; set; }
    public string Dosage { get; set; }      
    public string Frequency { get; set; }   
    public int DurationDays { get; set; }   
    public string Instructions { get; set; } 
}
