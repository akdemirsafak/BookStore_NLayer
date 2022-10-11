using AutoMapper;
using BookStore.Core.BaseDtos;
using BookStore.Core.Dtos.BookDtos;
using BookStore.Core.Entity;
using BookStore.Core.RepositoryCore;
using BookStore.Core.ServiceCore;
using BookStore.Core.UnitOfWorkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Service.Services;

public class BookService : GenericService<Book>, IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IGenericRepository<Book> genericRepository, IUnitOfWork unitOfWork,
        IBookRepository bookRepository, IMapper mapper) : base(genericRepository, unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponseDto<List<BookDto>>> GetAll()
    {
        var result = await _bookRepository.GetAll().ToListAsync();
        var mappedDto = _mapper.Map<List<BookDto>>(result);
        return ApiResponseDto<List<BookDto>>.Success(mappedDto, 200);
    }

    public async Task<ApiResponseDto<BookDto>> GetById(int id)
    {
        var result = await _bookRepository.FindAsync(id);
        var mappedDto = _mapper.Map<BookDto>(result);
        return ApiResponseDto<BookDto>.Success(mappedDto, 200);
    }

    public async Task<ApiResponseDto<BookWithDetailsDto>> GetWithDetailsByIdAsync(int id)
    {
        var result = await _bookRepository.GetWithDetailsByIdAsync(id);
        var mappedResult = _mapper.Map<BookWithDetailsDto>(result);
        return ApiResponseDto<BookWithDetailsDto>.Success(mappedResult, 200);
    }

    public async Task<ApiResponseDto<NoContentDto>> DeleteAsync(int id)
    {
        var result = await _bookRepository.DeleteAsync(id);
        if (result > 0) return ApiResponseDto<NoContentDto>.Success(204);
        return ApiResponseDto<NoContentDto>.Fail("Kitap silinemedi.", 500);
    }

    public async Task<ApiResponseDto<NoContentDto>> CreateAsync(CreateBookDto book)
    {
        var bookEntity = _mapper.Map<Book>(book);
        await _bookRepository.AddAsync(bookEntity);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<NoContentDto>.Success(201);
    }

    public async Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateBookDto book)
    {
        var bookEntity = _mapper.Map<Book>(book);
        var result = await _bookRepository.UpdateAsync(bookEntity);
        if (result > 0) return ApiResponseDto<NoContentDto>.Success(204);
        return ApiResponseDto<NoContentDto>.Fail("Güncelleme başarısız.", 500);
    }
}