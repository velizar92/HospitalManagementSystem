namespace HospitalManagementSystem.Domain.Models;

public class Invoice
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public bool IsPaid { get; set; } = false;
    public ICollection<InvoiceItem> Items { get; set; } = [];
    public int? AppointmentId { get; set; } 
    public Appointment? Appointment { get; set; } 
}