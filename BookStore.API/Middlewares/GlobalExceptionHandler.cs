using BookStore.Core.BaseDtos;
using BookStore.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStore.API.Middlewares;

public static class GlobalExceptionHandler
{
    public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(options =>
        {
            options.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                var statusCode = exceptionFeature.Error switch
                {
                    ClientSideException => 400,
                    NotFoundException => 404,
                    _ => 500
                };
                context.Response.StatusCode = statusCode;
                var response = ApiResponseDto<NoContent>.Fail(exceptionFeature.Error.Message, statusCode);
                await context.Response.WriteAsJsonAsync(response);
            });
        });
    }
}