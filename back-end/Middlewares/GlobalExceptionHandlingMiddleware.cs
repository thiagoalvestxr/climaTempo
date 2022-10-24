using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ClimaTempo.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;           
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
           try
           {
                await next(context);
           }
           catch(Exception ex)
           {
                _logger.LogError(ex, ex.Message);

                var problem = new ProblemDetails
                {
                    Status = (int) HttpStatusCode.InternalServerError,
                    Type = "Server error", 
                    Title = "Server error", 
                    Detail = "An internal server error has occurred"
                };

                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(problem);
           }
        }
    }
}