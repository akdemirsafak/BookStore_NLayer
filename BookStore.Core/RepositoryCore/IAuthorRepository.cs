using BookStore.Core.Entity;

namespace BookStore.Core.RepositoryCore;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<Author> GetWithBooksByIdAsync(int id);
    Task<int> UpdateAsync(Author author);
    Task<int> DeleteAsync(int id);
}