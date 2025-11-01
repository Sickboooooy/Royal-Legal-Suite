namespace RoyalLegal.Domain.Entities;

public class InvoiceLineItem : BaseEntity
{
    public int InvoiceId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal Rate { get; set; }
    public decimal Amount { get; set; }

    // Navigation properties
    public virtual Invoice Invoice { get; set; } = null!;
}