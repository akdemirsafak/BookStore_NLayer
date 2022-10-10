using BookStore.Core.BaseDtos;
using BookStore.Core.Dtos.AuthorDtos;
using BookStore.Core.Entity;

namespace BookStore.Core.ServiceCore;

public interface IAuthorService : IGenericService<Author>
{
    Task<ApiResponseDto<List<AuthorDto>>> GetAll();
    Task<ApiResponseDto<AuthorDto>> GetById(int id);
    Task<ApiResponseDto<AuthorWithBooksDto>> GetWithBooksById(int id);
    Task<ApiResponseDto<NoContentDto>> CreateAsync(CreateAuthorDto author);
    Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateAuthorDto author);
    Task<ApiResponseDto<NoContentDto>> DeleteAsync(int id);
}