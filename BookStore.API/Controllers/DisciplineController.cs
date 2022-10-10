using BookStore.Core.Dtos.DisciplineDtos;
using BookStore.Core.ServiceCore;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

public class DisciplineController : CustomBaseController
{
    private readonly IDisciplineService _disciplineService;


    public DisciplineController(IDisciplineService disciplineService)
    {
        _disciplineService = disciplineService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _disciplineService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _disciplineService.GetById(id));
    }

    [HttpGet("GetWithBooksById/{id}")]
    public async Task<IActionResult> GetWithBooksById(int id)
    {
        return CreateActionResult(await _disciplineService.GetWithBooksByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDisciplineDto disciplineDto)
    {
        return CreateActionResult(await _disciplineService.CreateAsync(disciplineDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateDisciplineDto disciplineDto)
    {
        return CreateActionResult(await _disciplineService.UpdateAsync(disciplineDto));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _disciplineService.DeleteAsync(id));
    }
}