using HospitalManagementSystem.Application.DTOs.Invoice;
using HospitalManagementSystem.Application.Interfaces;

namespace HospitalManagementSystem.Application.Implementations;

public class InvoiceService : IInvoiceService
{
    public Task<int> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteInvoiceAsync(int invoiceId)
    {
        throw new NotImplementedException();
    }

    public Task<InvoiceDto?> GetInvoiceAsync(int invoiceId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<InvoiceDto>> GetInvoicesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<InvoiceDto>> GetInvoicesByPatientIdAsync(int patientId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<InvoiceDto>> GetUnpaidInvoicesAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateInvoiceAsync(UpdateInvoiceDto updateInvoiceDto)
    {
        throw new NotImplementedException();
    }
}
