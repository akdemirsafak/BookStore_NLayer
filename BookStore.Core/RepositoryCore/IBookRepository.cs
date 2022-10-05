using BookStore.Core.Entity;

namespace BookStore.Core.RepositoryCore;

public interface IBookRepository:IGenericRepository<Book>
{
  
    Task<int> DeleteAsync(int id);
    int Delete(int id);
    int Update(Book entity);
    Task<int> UpdateAsync(Book entity);
}