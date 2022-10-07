using System.Linq.Expressions;

namespace BookStore.Core.RepositoryCore;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll();
    Task<T> FindAsync(int id);
    IQueryable<T> Where(Expression<Func<T, bool>> condition);
    Task<bool> AnyAsync(Expression<Func<T, bool>> condition);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
}