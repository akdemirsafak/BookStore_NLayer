using System.Linq.Expressions;

namespace BookStore.Core.ServiceCore;

public interface IGenericService<T> where T : class
{
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
}