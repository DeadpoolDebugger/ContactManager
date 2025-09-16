using System;
using Application.Interfaces;
using Persistence.Data;

namespace Persistence.Repositories;

public class UnitofWork(AppDbContext context) : IUnitofWork
{
    private readonly AppDbContext _context = context;
    private readonly Dictionary<Type, object> _repositories = new();

    public IGenericRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
        {
            var repoInstance = Activator.CreateInstance(typeof(GenericRepository<>)
                              .MakeGenericType(type), _context) ??
                              throw new InvalidOperationException($"Could not create repository for type {type.Name}");

            _repositories[type] = repoInstance;
        }
        return (IGenericRepository<T>)_repositories[type]!;
    }

    public async Task<int> SaveChangesAsync()
    => await _context.SaveChangesAsync();

    public void Dispose()
    => _context.Dispose();
}
