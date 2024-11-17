using System.Net;
using WebMenuAPI.Models; // Asegúrate de tener un modelo para la respuesta de error
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace WebMenuAPI.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // Llamar al siguiente middleware
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones global
                _logger.LogError($"An error occurred while processing your request: {ex.Message}");

                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    Title = ex.GetType().Name,
                    StatusCode = (int)HttpStatusCode.InternalServerError // Por defecto es error 500
                };

                if (ex is BadHttpRequestException)
                {
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                httpContext.Response.StatusCode = errorResponse.StatusCode;
                httpContext.Response.ContentType = "application/json";

                // Enviar la respuesta de error como JSON
                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }

    // Modelo para la respuesta de error
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
    }
}
