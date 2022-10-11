using AutoMapper;
using BookStore.Core.BaseDtos;
using BookStore.Core.Dtos.AuthorDtos;
using BookStore.Core.Entity;
using BookStore.Core.RepositoryCore;
using BookStore.Core.ServiceCore;
using BookStore.Core.UnitOfWorkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Service.Services;

public class AuthorService : GenericService<Author>, IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AuthorService(IGenericRepository<Author> genericRepository, IUnitOfWork unitOfWork,
        IMapper mapper, IAuthorRepository authorRepository) : base(genericRepository, unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authorRepository = authorRepository;
    }

    public async Task<ApiResponseDto<List<AuthorDto>>> GetAll()
    {
        var authors = await _authorRepository.GetAll().ToListAsync();
        var authorsMapped = _mapper.Map<List<AuthorDto>>(authors);
        return ApiResponseDto<List<AuthorDto>>.Success(authorsMapped, 200);
    }

    public async Task<ApiResponseDto<AuthorDto>> GetById(int id)
    {
        var author = await _authorRepository.FindAsync(id);
        var authorMapped = _mapper.Map<AuthorDto>(author);
        return ApiResponseDto<AuthorDto>.Success(authorMapped, 200);
    }

    public async Task<ApiResponseDto<AuthorWithBooksDto>> GetWithBooksById(int id)
    {
        var author = await _authorRepository.GetWithBooksByIdAsync(id);
        var authorMapped = _mapper.Map<AuthorWithBooksDto>(author);
        return ApiResponseDto<AuthorWithBooksDto>.Success(authorMapped, 200);
    }

    public async Task<ApiResponseDto<NoContentDto>> CreateAsync(CreateAuthorDto author)
    {
        var authorEntity = _mapper.Map<Author>(author);
        await _authorRepository.AddAsync(authorEntity);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<NoContentDto>.Success(201);
    }

    public async Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateAuthorDto author)
    {
        var authorEntity = _mapper.Map<Author>(author);
        var affectedRowCount = await _authorRepository.UpdateAsync(authorEntity);

        if (affectedRowCount > 0) return ApiResponseDto<NoContentDto>.Success(204);
        return ApiResponseDto<NoContentDto>.Fail("Yazar güncellenemedi.", 500);
    }

    public async Task<ApiResponseDto<NoContentDto>> DeleteAsync(int id)
    {
        var affectedRowCount = await _authorRepository.DeleteAsync(id);

        if (affectedRowCount > 0) return ApiResponseDto<NoContentDto>.Success(204);
        return ApiResponseDto<NoContentDto>.Fail("Yazar silinemedi.", 500);
    }
}