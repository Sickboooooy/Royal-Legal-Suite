namespace RoyalLegal.Domain.Entities;

public class TimeEntry : BaseEntity
{
    public int UserId { get; set; }
    public int CaseId { get; set; }
    public int? TaskId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public decimal Hours { get; set; }
    public decimal HourlyRate { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsBillable { get; set; } = true;
    public bool IsInvoiced { get; set; } = false;
    public int? InvoiceId { get; set; }
    public string Notes { get; set; } = string.Empty;

    // Navigation properties
    public virtual User User { get; set; } = null!;
    public virtual Case Case { get; set; } = null!;
    public virtual Task? Task { get; set; }
    public virtual Invoice? Invoice { get; set; }

    public decimal TotalAmount => Hours * HourlyRate;
}