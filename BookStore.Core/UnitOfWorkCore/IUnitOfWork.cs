namespace BookStore.Core.UnitOfWorkCore;

public interface IUnitOfWork
{
    int Commit();
    Task CommitAsync();
}