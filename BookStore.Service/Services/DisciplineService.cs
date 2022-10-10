using AutoMapper;
using BookStore.Core.BaseDtos;
using BookStore.Core.Dtos.DisciplineDtos;
using BookStore.Core.Entity;
using BookStore.Core.RepositoryCore;
using BookStore.Core.ServiceCore;
using BookStore.Core.UnitOfWorkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Service.Services;

public class DisciplineService : GenericService<Discipline>, IDisciplineService
{
    private readonly IDisciplineRepository _disciplineRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DisciplineService(IGenericRepository<Discipline> genericRepository, IUnitOfWork unitOfWork,
        IDisciplineRepository disciplineRepository, IMapper mapper) : base(genericRepository, unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _disciplineRepository = disciplineRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponseDto<List<DisciplineDto>>> GetAll()
    {
        var result = await _disciplineRepository.GetAll().ToListAsync();
        var mappedDisciplinesDto = _mapper.Map<List<DisciplineDto>>(result);
        return ApiResponseDto<List<DisciplineDto>>.Success(200, mappedDisciplinesDto);
    }

    public async Task<ApiResponseDto<DisciplineDto>> GetById(int id)
    {
        var result = await _disciplineRepository.FindAsync(id);
        var mappedDisciplineDto = _mapper.Map<DisciplineDto>(result);
        return ApiResponseDto<DisciplineDto>.Success(200, mappedDisciplineDto);
    }


    public async Task<ApiResponseDto<NoContentDto>> CreateAsync(CreateDisciplineDto discipline)
    {
        var disciplineEntity = _mapper.Map<Discipline>(discipline);
        await _disciplineRepository.AddAsync(disciplineEntity);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<NoContentDto>.Success(201);
    }

    public async Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateDisciplineDto discipline)
    {
        var disciplineEntity = _mapper.Map<Discipline>(discipline);
        var affectedRowCount = await _disciplineRepository.UpdateAsync(disciplineEntity);
        if (affectedRowCount > 0) return ApiResponseDto<NoContentDto>.Success(204);
        return ApiResponseDto<NoContentDto>.Fail(500, "Disiplin güncellenemedi.");
    }

    public async Task<ApiResponseDto<NoContentDto>> DeleteAsync(int id)
    {
        var affectedRowCount = await _disciplineRepository.DeleteAsync(id);

        if (affectedRowCount > 0) return ApiResponseDto<NoContentDto>.Success(204);
        return ApiResponseDto<NoContentDto>.Fail(500, "Disiplin silinemedi.");
    }

    public async Task<ApiResponseDto<DisciplineWithBooksDto>> GetWithBooksByIdAsync(int id)
    {
        var result = await _disciplineRepository.GetWithBooksByIdAsync(id);
        var mappedDto = _mapper.Map<DisciplineWithBooksDto>(result);
        return ApiResponseDto<DisciplineWithBooksDto>.Success(200, mappedDto);
    }
}