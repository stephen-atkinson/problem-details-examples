using System.Diagnostics;
using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MvcProblems;

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();