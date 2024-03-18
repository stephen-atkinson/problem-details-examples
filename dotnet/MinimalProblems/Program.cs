using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddProblemDetails(o =>
{
    o.CustomizeProblemDetails = c =>
    {
        c.ProblemDetails.Instance = c.HttpContext.Request.Path;
        c.ProblemDetails.Extensions
            .Add("traceId", Activity.Current?.Id ?? c.HttpContext.TraceIdentifier);
    };
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/orders/{id:int}", (int id) =>
{
    // return Results.Forbid();
    // return Results.BadRequest();
    // return Results.Problem();
    // return Results.ValidationProblem()
    return Results.NotFound();
});


app.Run();