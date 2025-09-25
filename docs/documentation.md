# CONTACT MANAGER DOCUMENTATION

## BACKEND DEVELOPMENT - C# (WebAPI, Class Library)
### Domain Layer (Models)
>`Domain/Entities/Contact.cs`<br /> Keeps entity definitions independent of EF - supports domain-first approach
```csharp
namespace Domain.Entities;
public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
```

### Application Layer (DTO, interfaces, CQRS)
>`Application/DTO/ContactDTO.cs` <br/>
DTOs allow us to send only the data needed for a particular task, minimizing the amount of data transmitted over the network or passed between application layers.
```csharp
namespace Application.DTO;
public class ContactDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public string Address { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}
```
>`Application/Interfaces/IGenericRepository.cs`
```csharp
using System.Linq.Expressions;
namespace Application.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}
```
>`Application/Interfaces/IUnitOfWork.cs`
```csharp
namespace Application.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : class;
    Task<int> SaveChangesAsync();
}
```

### Persistence Layer (EF Core, Generic Repository, UnitOfWork)
