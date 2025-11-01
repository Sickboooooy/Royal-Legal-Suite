using RoyalLegal.Domain.Enums;

namespace RoyalLegal.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public string BarNumber { get; set; } = string.Empty;
    public DateTime? HireDate { get; set; }
    public decimal HourlyRate { get; set; }
    public bool IsActive { get; set; } = true;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime? LastLogin { get; set; }

    // Navigation properties
    public virtual ICollection<Case> AssignedCases { get; set; } = new List<Case>();
    public virtual ICollection<Task> AssignedTasks { get; set; } = new List<Task>();
    public virtual ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();

    public string FullName => $"{FirstName} {LastName}";
}