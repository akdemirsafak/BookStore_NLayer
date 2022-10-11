using System.Linq.Expressions;
using BookStore.Core.RepositoryCore;
using BookStore.Core.ServiceCore;
using BookStore.Core.UnitOfWorkCore;

namespace BookStore.Service.Services;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly IGenericRepository<T> _genericRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GenericService(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
    {
        _genericRepository = genericRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return _genericRepository.AnyAsync(expression);
    }
}