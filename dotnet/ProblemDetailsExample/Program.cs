using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProblemDetailsExample;
using Recipes.Core.Application.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetRequiredSection("Jwt"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.ConfigureOptions<JwtConfigOptions>();

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<SwaggerConfigOptions>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddProblemDetails(o =>
{
    o.CustomizeProblemDetails = c =>
        c.ProblemDetails.Instance = c.HttpContext.Request.Path;
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStatusCodePages();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

// app.MapGet("/orders/{id:int}", (int id) =>
// {
//     // return Results.Forbid();
//     // return Results.BadRequest();
//     // return Results.Problem();
//     // return Results.ValidationProblem()
//     return Results.BadRequest();
// });

app.MapControllers(); //.RequireAuthorization();

app.Run();
