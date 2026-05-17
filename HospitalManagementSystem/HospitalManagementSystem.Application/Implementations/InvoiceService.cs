using HospitalManagementSystem.Application.DTOs.Invoice;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Implementations;

public class InvoiceService : IInvoiceService
{
    private readonly HospitalManagementSystemDbContext _dbContext;

    public InvoiceService(HospitalManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;

    }
    public async Task<int> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto)
    {
        var invoice = new Invoice
        {
            PatientId = createInvoiceDto.PatientId,
            AppointmentId = createInvoiceDto.AppointmentId,
            CreatedAt = createInvoiceDto.CreatedAt ?? DateTime.UtcNow,
            Items = createInvoiceDto.Items.Select(invoiceItem => new InvoiceItem
            {
                Description = invoiceItem.Description,
                Amount = invoiceItem.UnitPrice * invoiceItem.Quantity,
            }).ToList()
        };

        await _dbContext.AddAsync(invoice);
        await _dbContext.SaveChangesAsync();

        return invoice.Id;
    }

    public async Task<InvoiceDto?> GetInvoiceAsync(int invoiceId)
    {
        return await _dbContext.Invoices
            .Where(invoice => invoice.Id == invoiceId)
            .Select(invoice => new InvoiceDto
            {
                Id = invoice.Id,
                PatientId = invoice.PatientId,
                CreatedAt = invoice.CreatedAt,
                TotalAmount = invoice.Items.Sum(item => item.Amount),
                IsPaid = invoice.IsPaid,
                AppointmentId = invoice.AppointmentId,
                Items = invoice.Items.Select(item => new InvoiceItemDto
                {
                    Description = item.Description,
                    UnitPrice = item.Amount,
                    Quantity = 1
                }).ToList(),
                PatientFullName = $"{invoice.Patient.Profile.FirstName} {invoice.Patient.Profile.LastName}"
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<InvoiceDto>> GetInvoicesAsync()
    {
        return await _dbContext.Invoices
             .Select(invoice => new InvoiceDto
             {
                 Id = invoice.Id,
                 PatientId = invoice.PatientId,
                 CreatedAt = invoice.CreatedAt,
                 TotalAmount = invoice.Items.Sum(item => item.Amount),
                 IsPaid = invoice.IsPaid,
                 AppointmentId = invoice.AppointmentId,
                 Items = invoice.Items.Select(item => new InvoiceItemDto
                 {
                     Description = item.Description,
                     UnitPrice = item.Amount,
                     Quantity = 1
                 }).ToList(),
                 PatientFullName = $"{invoice.Patient.Profile.FirstName} {invoice.Patient.Profile.LastName}"
             })
             .ToListAsync();
    }

    public async Task<IEnumerable<InvoiceDto>> GetInvoicesByPatientIdAsync(int patientId)
    {
        return await _dbContext.Invoices
            .Where(invoice => invoice.PatientId == patientId)
            .Select(invoice => new InvoiceDto
            {
                Id = invoice.Id,
                PatientId = invoice.PatientId,
                CreatedAt = invoice.CreatedAt,
                TotalAmount = invoice.Items.Sum(item => item.Amount),
                IsPaid = invoice.IsPaid,
                AppointmentId = invoice.AppointmentId,
                Items = invoice.Items.Select(item => new InvoiceItemDto
                {
                    Description = item.Description,
                    UnitPrice = item.Amount,
                    Quantity = 1
                }).ToList(),
                PatientFullName = $"{invoice.Patient.Profile.FirstName} {invoice.Patient.Profile.LastName}"
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<InvoiceDto>> GetUnpaidInvoicesAsync()
    {
        return await _dbContext.Invoices
            .Where(invoice => !invoice.IsPaid)
            .Select(invoice => new InvoiceDto
            {
                Id = invoice.Id,
                PatientId = invoice.PatientId,
                CreatedAt = invoice.CreatedAt,
                TotalAmount = invoice.Items.Sum(item => item.Amount),
                IsPaid = invoice.IsPaid,
                AppointmentId = invoice.AppointmentId,
                Items = invoice.Items.Select(item => new InvoiceItemDto
                {
                    Description = item.Description,
                    UnitPrice = item.Amount,
                    Quantity = 1
                }).ToList(),
                PatientFullName = $"{invoice.Patient.Profile.FirstName} {invoice.Patient.Profile.LastName}"
            })
            .ToListAsync();
    }

    public async Task UpdateInvoiceAsync(UpdateInvoiceDto updateInvoiceDto)
    {
        var invoice = await _dbContext.Invoices.FindAsync(updateInvoiceDto.Id);

        if (invoice == null)
        {
            throw new KeyNotFoundException("Invoice not found");
        }

        invoice.Id = updateInvoiceDto.Id;
        invoice.IsPaid = updateInvoiceDto.IsPaid ?? invoice.IsPaid;
        invoice.Items = updateInvoiceDto.Items.Select(invoiceItem => new InvoiceItem
        {
            Description = invoiceItem.Description,
            Amount = invoiceItem.UnitPrice * invoiceItem.Quantity,
        }).ToList();

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteInvoiceAsync(int invoiceId)
    {
        var invoice = await _dbContext.Invoices.FindAsync(invoiceId);

        if (invoice == null)
        {
            throw new KeyNotFoundException("Invoice not found");
        }

        _dbContext.Invoices.Remove(invoice);
        await _dbContext.SaveChangesAsync();
    }
}
