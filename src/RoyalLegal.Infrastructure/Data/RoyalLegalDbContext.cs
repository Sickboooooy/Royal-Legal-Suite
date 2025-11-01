using Microsoft.EntityFrameworkCore;
using RoyalLegal.Domain.Entities;

namespace RoyalLegal.Infrastructure.Data;

public class RoyalLegalDbContext : DbContext
{
    public RoyalLegalDbContext(DbContextOptions<RoyalLegalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Case> Cases { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
    public DbSet<CaseEvent> CaseEvents { get; set; }
    public DbSet<CaseParticipant> CaseParticipants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure decimal precision
        modelBuilder.Entity<Case>()
            .Property(c => c.EstimatedValue)
            .HasPrecision(18, 2);

        modelBuilder.Entity<User>()
            .Property(u => u.HourlyRate)
            .HasPrecision(18, 2);

        modelBuilder.Entity<TimeEntry>()
            .Property(t => t.Hours)
            .HasPrecision(18, 2);

        modelBuilder.Entity<TimeEntry>()
            .Property(t => t.HourlyRate)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Invoice>()
            .Property(i => i.SubTotal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Invoice>()
            .Property(i => i.TaxRate)
            .HasPrecision(5, 4);

        modelBuilder.Entity<Invoice>()
            .Property(i => i.TaxAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Invoice>()
            .Property(i => i.TotalAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Invoice>()
            .Property(i => i.PaidAmount)
            .HasPrecision(18, 2);

        // Configure relationships
        modelBuilder.Entity<Case>()
            .HasOne(c => c.Client)
            .WithMany(cl => cl.Cases)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Case>()
            .HasOne(c => c.AssignedLawyer)
            .WithMany(u => u.AssignedCases)
            .HasForeignKey(c => c.AssignedLawyerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Task>()
            .HasOne(t => t.Case)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CaseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Task>()
            .HasOne(t => t.AssignedToUser)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(t => t.AssignedToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure indexes
        modelBuilder.Entity<Client>()
            .HasIndex(c => c.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        modelBuilder.Entity<Case>()
            .HasIndex(c => c.CaseNumber)
            .IsUnique();

        modelBuilder.Entity<Invoice>()
            .HasIndex(i => i.InvoiceNumber)
            .IsUnique();
    }
}