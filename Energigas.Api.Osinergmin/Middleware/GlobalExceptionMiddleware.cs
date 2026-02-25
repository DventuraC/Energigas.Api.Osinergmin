using Shared.Common;

namespace Energigas.Api.Osinergmin.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext http)
        {
            try
            {
                await _next(http);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error no controlado");

                http.Response.StatusCode = 500;
                http.Response.ContentType = "application/json";

                var response = ApiResponse<string>.Fail(
                    "Error interno del servidor",
                    500,
                    new List<string> { ex.Message});

                await http.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
