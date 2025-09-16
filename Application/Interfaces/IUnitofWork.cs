using System;

namespace Application.Interfaces;

public interface IUnitofWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : class;
    Task<int> SaveChangesAsync();
}
