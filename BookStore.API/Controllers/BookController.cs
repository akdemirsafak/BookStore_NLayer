using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Controllers;

public class BookController : CustomBaseController
{
    private readonly BookStoreDBContext _dbContext;


    public BookController(BookStoreDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _dbContext.Books.ToListAsync());
        //return CreateActionResult();
    }
}