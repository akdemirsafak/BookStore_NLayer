using BookStore.Core.Entity;

namespace BookStore.Core.RepositoryCore;

public interface IDisciplineRepository : IGenericRepository<Discipline>
{
    Task<Discipline> GetWithBooksByIdAsync(int id);
    Task<int> UpdateAsync(Discipline discipline);
    Task<int> DeleteAsync(int id);
}