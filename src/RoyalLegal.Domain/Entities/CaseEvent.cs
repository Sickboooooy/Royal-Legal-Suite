namespace RoyalLegal.Domain.Entities;

public class CaseEvent : BaseEntity
{
    public int CaseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public DateTime? ReminderDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public bool IsAllDay { get; set; } = false;
    public string Notes { get; set; } = string.Empty;

    // Navigation properties
    public virtual Case Case { get; set; } = null!;
}