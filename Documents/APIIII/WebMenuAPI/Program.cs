using WebMenuAPI.Context;
using WebMenuAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configuration for DbSettings
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

// Register the ContextoBD with dependency injection
builder.Services.AddDbContext<ContextoBD>();

var app = builder.Build();

// Ensure database context is initialized
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ContextoBD>();
}

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
