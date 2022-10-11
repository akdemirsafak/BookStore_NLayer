using BookStore.Core.BaseDtos;
using BookStore.Core.Entity;
using BookStore.Core.ServiceCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.API.Filters;

public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
{
    private readonly IGenericService<T> _service;

    public NotFoundFilter(IGenericService<T> service)
    {
        _service = service;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var idValue = context.ActionArguments.Values.FirstOrDefault();
        if (idValue == null)
        {
            await next.Invoke();
            return;
        }

        var id = (int)idValue;
        var anyEntity = await _service.AnyAsync(x => x.Id == id);
        if (anyEntity)
        {
            await next.Invoke();
            return;
        }

        context.Result =
            new NotFoundObjectResult(ApiResponseDto<NoContentDto>.Fail($"{typeof(T).Name} : ({id}) not found.", 404));
    }
}