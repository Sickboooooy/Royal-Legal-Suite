namespace RoyalLegal.Domain.Enums;

public enum CaseType
{
    Criminal,
    Civil,
    Family,
    Corporate,
    Immigration,
    PersonalInjury,
    RealEstate,
    Employment,
    Intellectual Property,
    Tax,
    Bankruptcy,
    Other
}

public enum CaseStatus
{
    Open,
    InProgress,
    OnHold,
    Closed,
    Cancelled,
    Settled,
    Won,
    Lost
}

public enum Priority
{
    Low,
    Medium,
    High,
    Critical
}

public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed,
    Cancelled,
    OnHold
}

public enum DocumentType
{
    Contract,
    Motion,
    Brief,
    Correspondence,
    Evidence,
    Discovery,
    Pleading,
    Settlement,
    Other
}

public enum UserRole
{
    Admin,
    Lawyer,
    Paralegal,
    Secretary,
    Client
}

public enum InvoiceStatus
{
    Draft,
    Sent,
    Paid,
    Overdue,
    Cancelled
}