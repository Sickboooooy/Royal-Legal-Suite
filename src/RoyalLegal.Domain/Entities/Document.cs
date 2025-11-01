using RoyalLegal.Domain.Enums;

namespace RoyalLegal.Domain.Entities;

public class Document : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string MimeType { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public DocumentType DocumentType { get; set; }
    public int CaseId { get; set; }
    public int? ClientId { get; set; }
    public bool IsConfidential { get; set; } = false;
    public DateTime? ExpirationDate { get; set; }
    public string Tags { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;

    // Navigation properties
    public virtual Case Case { get; set; } = null!;
    public virtual Client? Client { get; set; }
}