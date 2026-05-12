namespace HospitalManagementSystem.Domain.Models;

public class InvoiceItem
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}

