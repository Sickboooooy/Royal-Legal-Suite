using RoyalLegal.Domain.Enums;

namespace RoyalLegal.Domain.Entities;

public class Case : BaseEntity
{
    public string CaseNumber { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CaseType CaseType { get; set; }
    public CaseStatus Status { get; set; } = CaseStatus.Open;
    public Priority Priority { get; set; } = Priority.Medium;
    public DateTime OpenDate { get; set; } = DateTime.UtcNow;
    public DateTime? CloseDate { get; set; }
    public decimal EstimatedValue { get; set; }
    public int ClientId { get; set; }
    public int AssignedLawyerId { get; set; }
    public string Court { get; set; } = string.Empty;
    public string JudgeName { get; set; } = string.Empty;
    public string OpposingParty { get; set; } = string.Empty;
    public string OpposingCounsel { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;

    // Navigation properties
    public virtual Client Client { get; set; } = null!;
    public virtual User AssignedLawyer { get; set; } = null!;
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    public virtual ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
    public virtual ICollection<CaseEvent> Events { get; set; } = new List<CaseEvent>();
    public virtual ICollection<CaseParticipant> Participants { get; set; } = new List<CaseParticipant>();
}