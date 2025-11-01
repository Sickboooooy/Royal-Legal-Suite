namespace RoyalLegal.Domain.Entities;

public class CaseParticipant : BaseEntity
{
    public int CaseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;

    // Navigation properties
    public virtual Case Case { get; set; } = null!;
}