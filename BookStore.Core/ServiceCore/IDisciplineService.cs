using BookStore.Core.BaseDtos;
using BookStore.Core.Dtos.DisciplineDtos;
using BookStore.Core.Entity;

namespace BookStore.Core.ServiceCore;

public interface IDisciplineService : IGenericService<Discipline>
{
    Task<ApiResponseDto<List<DisciplineDto>>> GetAll();
    Task<ApiResponseDto<DisciplineDto>> GetById(int id);
    Task<ApiResponseDto<NoContentDto>> CreateAsync(CreateDisciplineDto discipline);
    Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateDisciplineDto discipline);
    Task<ApiResponseDto<NoContentDto>> DeleteAsync(int id);
    Task<ApiResponseDto<DisciplineWithBooksDto>> GetWithBooksByIdAsync(int id);
}