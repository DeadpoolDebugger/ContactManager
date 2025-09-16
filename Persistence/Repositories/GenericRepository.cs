using System.Linq.Expressions;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context = context;
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    => await _context.Set<T>().Where(predicate).ToListAsync();

    public async Task<IEnumerable<T>> GetAllAsync()
    => await _context.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(int id)
    => await _context.Set<T>().FindAsync(id);

    public void Remove(T entity)
    => _context.Set<T>().Remove(entity);

    public void Update(T entity)
    => _context.Set<T>().Update(entity);
}
