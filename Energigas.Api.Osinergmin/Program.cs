using Application;
using Energigas.Api.Osinergmin.Middleware;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using Shared.Common;

var builder = WebApplication.CreateBuilder(args);

// Swager
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(e =>
{
    e.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Energigas Api Osinergmin",
        Version = "v1"
    });
});

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        var response = ApiResponse<object>.Fail(
            "Errores de validación",
            400,
            errors);

        return new BadRequestObjectResult(response);
    };
});

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(e =>
    {
        e.SwaggerEndpoint("/swagger/v1/swagger.json", "Energigas Api Osinergmin v1");
    });
}


// Configure the HTTP request pipeline.

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
