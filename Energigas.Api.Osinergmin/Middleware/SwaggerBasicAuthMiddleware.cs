using System.Text;

namespace Energigas.Api.Osinergmin.Middleware
{
    public class SwaggerBasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public SwaggerBasicAuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Solo aplica a rutas de swagger
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                string authHeader = context.Request.Headers["Authorization"];

                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
                    var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
                    var parts = decodedCredentials.Split(':', 2);

                    var username = parts[0];
                    var password = parts[1];

                    var validUser = _configuration["SwaggerAuth:Username"];
                    var validPass = _configuration["SwaggerAuth:Password"];

                    if (username == validUser && password == validPass)
                    {
                        await _next.Invoke(context);
                        return;
                    }
                }

                context.Response.Headers["WWW-Authenticate"] = "Basic";
                context.Response.StatusCode = 401;
                return;
            }

            await _next.Invoke(context);
        }
    }
}
