namespace RoyalLegal.Domain.Entities;

public class Client : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string SocialSecurityNumber { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public bool IsCompany { get; set; } = false;
    public string Notes { get; set; } = string.Empty;

    // Navigation properties
    public virtual ICollection<Case> Cases { get; set; } = new List<Case>();
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public string FullName => IsCompany ? CompanyName : $"{FirstName} {LastName}";
}