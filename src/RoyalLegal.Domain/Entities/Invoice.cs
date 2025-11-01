using RoyalLegal.Domain.Enums;

namespace RoyalLegal.Domain.Entities;

public class Invoice : BaseEntity
{
    public string InvoiceNumber { get; set; } = string.Empty;
    public int ClientId { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;
    public decimal SubTotal { get; set; }
    public decimal TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime? PaidDate { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;

    // Navigation properties
    public virtual Client Client { get; set; } = null!;
    public virtual ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
    public virtual ICollection<InvoiceLineItem> LineItems { get; set; } = new List<InvoiceLineItem>();

    public decimal BalanceDue => TotalAmount - PaidAmount;
}