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

                if (http.Response.StatusCode == 401)
                {
                    http.Response.ContentType = "application/json";

                    var response = ApiResponse<string>.Fail("No estás autenticado autorizado",401);
                    await http.Response.WriteAsJsonAsync(response);
                }
                else if (http.Response.StatusCode == 403)
                {
                    http.Response.ContentType = "application/json";

                    var response = ApiResponse<object>.Fail("No tienes permisos para acceder a este recurso.", 403);
                    await http.Response.WriteAsJsonAsync(response);
                }

            }
            catch (OsinergminException ex)
            {
                http.Response.StatusCode = 503;
                http.Response.ContentType = "application/json";
                var response = ApiResponse<string>.Fail(
                    ex.Message,
                    503,
                    new List<string> { ex.CodeError });
                await http.Response.WriteAsJsonAsync(response);
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
