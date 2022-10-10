using BookStore.Core.Dtos.BookDtos;
using BookStore.Core.ServiceCore;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

public class BookController : CustomBaseController
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _bookService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _bookService.GetById(id));
    }

    [HttpGet("GetWithDetailsById/{id}")]
    public async Task<IActionResult> GetWithDetailsById(int id)
    {
        return CreateActionResult(await _bookService.GetWithDetailsByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookDto bookDto)
    {
        return CreateActionResult(await _bookService.CreateAsync(bookDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBookDto bookDto)
    {
        return CreateActionResult(await _bookService.UpdateAsync(bookDto));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _bookService.DeleteAsync(id));
    }
}