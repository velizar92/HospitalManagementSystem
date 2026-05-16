using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Invoice;

public class CreateInvoiceItemDto
{
    [Required]
    public string Description { get; set; } = string.Empty;

    [Range(0.0, double.MaxValue)]
    public decimal UnitPrice { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}
