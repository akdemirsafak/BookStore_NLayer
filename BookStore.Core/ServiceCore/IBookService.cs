using BookStore.Core.BaseDtos;
using BookStore.Core.Dtos.BookOperations;
using BookStore.Core.Entity;

namespace BookStore.Core.ServiceCore;

public interface IBookService : IGenericService<Book>
{
    Task<ApiResponseDto<List<BookDto>>> GetAll();
    Task<ApiResponseDto<BookDto>> GetById(int id);
    Task<ApiResponseDto<BookWithDetailsDto>> GetWithDetailsByIdAsync(int id);
    Task<ApiResponseDto<NoContentDto>> RemoveAsync(int id);
    Task<ApiResponseDto<NoContentDto>> CreateAsync(CreateBookDto book);
    Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateBookDto book);
}