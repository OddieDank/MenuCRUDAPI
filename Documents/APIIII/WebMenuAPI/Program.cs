using WebMenuAPI.Context;
using WebMenuAPI.Models;
using WebMenuAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configuration for DbSettings
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

// Register the ContextoBD with dependency injection
builder.Services.AddDbContext<ContextoBD>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddProblemDetails();  // Add this line

// Adding of login 
builder.Services.AddLogging();  // Add this line

var app = builder.Build();

// Ensure database context is initialized
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ContextoBD>();
}

// Register the GlobalExceptionHandler middleware manually
app.UseMiddleware<GlobalExceptionHandler>();  // Keep this line for middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
