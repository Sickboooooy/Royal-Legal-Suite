using RoyalLegal.Domain.Entities;

namespace RoyalLegal.Application.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}

public interface IClientRepository : IRepository<Client>
{
    Task<Client?> GetByEmailAsync(string email);
    Task<IEnumerable<Client>> GetClientsByCaseAsync(int caseId);
}

public interface ICaseRepository : IRepository<Case>
{
    Task<IEnumerable<Case>> GetCasesByClientAsync(int clientId);
    Task<IEnumerable<Case>> GetCasesByLawyerAsync(int lawyerId);
    Task<Case?> GetByCaseNumberAsync(string caseNumber);
}

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUserNameAsync(string userName);
    Task<IEnumerable<User>> GetLawyersAsync();
}

public interface ITimeEntryRepository : IRepository<TimeEntry>
{
    Task<IEnumerable<TimeEntry>> GetByCaseAsync(int caseId);
    Task<IEnumerable<TimeEntry>> GetByUserAsync(int userId);
    Task<IEnumerable<TimeEntry>> GetUnbilledEntriesAsync(int clientId);
}

public interface IInvoiceRepository : IRepository<Invoice>
{
    Task<IEnumerable<Invoice>> GetByClientAsync(int clientId);
    Task<Invoice?> GetByInvoiceNumberAsync(string invoiceNumber);
}

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }
    ICaseRepository Cases { get; }
    IUserRepository Users { get; }
    ITimeEntryRepository TimeEntries { get; }
    IInvoiceRepository Invoices { get; }
    IRepository<Document> Documents { get; }
    IRepository<Task> Tasks { get; }
    
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}