using System.Linq.Expressions;
using BookStore.Core.RepositoryCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly BookStoreDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> condition)
    {
        return _dbSet.Where(condition);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> condition)
    {
        return await _dbSet.AnyAsync(condition);
    }

    public async Task AddAsync(T entity)
    {
         await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }
    
}