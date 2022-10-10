using BookStore.Core.Dtos.AuthorDtos;
using BookStore.Core.ServiceCore;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

public class AuthorController : CustomBaseController
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _authorService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _authorService.GetById(id));
    }

    [HttpGet("GetWithBooksById/{id}")]
    public async Task<IActionResult> GetWithBooksById(int id)
    {
        return CreateActionResult(await _authorService.GetWithBooksById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorDto bookDto)
    {
        return CreateActionResult(await _authorService.CreateAsync(bookDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAuthorDto bookDto)
    {
        return CreateActionResult(await _authorService.UpdateAsync(bookDto));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _authorService.DeleteAsync(id));
    }
}