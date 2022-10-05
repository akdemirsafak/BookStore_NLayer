using BookStore.Core.BaseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ApiResponseDto<T> response)
    {
        if (response.StatusCode == 204) return new ObjectResult(null) { StatusCode = response.StatusCode };
        return new ObjectResult(response) { StatusCode = response.StatusCode };
    }
}