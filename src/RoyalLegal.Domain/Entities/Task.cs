using RoyalLegal.Domain.Enums;

namespace RoyalLegal.Domain.Entities;

public class Task : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatus Status { get; set; } = TaskStatus.NotStarted;
    public Priority Priority { get; set; } = Priority.Medium;
    public DateTime DueDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public int AssignedToUserId { get; set; }
    public int CaseId { get; set; }
    public decimal EstimatedHours { get; set; }
    public decimal ActualHours { get; set; }
    public string Notes { get; set; } = string.Empty;

    // Navigation properties
    public virtual User AssignedToUser { get; set; } = null!;
    public virtual Case Case { get; set; } = null!;
    public virtual ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
}