using WebMenuAPI.Context;
using WebMenuAPI.Models;
using WebMenuAPI.Middleware;
using WebMenuAPI.Interfaces;
using WebMenuAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
builder.Services.AddDbContext<ContextoBD>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddProblemDetails();  
builder.Services.AddLogging(); 
builder.Services.AddScoped<IComentarioServices, ComentarioServices>();
builder.Services.AddScoped<IPagoServices, PagoServices>();
builder.Services.AddScoped<ILocacionServices, LocacionServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<IProductoServices, ProductoServices>();
builder.Services.AddScoped<IOrdenServices, OrdenServices>();
builder.Services.AddScoped<IOrdenDetalleServices, OrdenDetalleServices>();
builder.Services.AddScoped<IStatusOrdenServices, StatusOrdenServices>();
builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigenLocal",
        policy => policy.WithOrigins("http://127.0.0.1:5500")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


var app = builder.Build();

{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ContextoBD>();
}


app.UseCors("PermitirOrigenLocal");

app.UseMiddleware<GlobalExceptionHandler>();  

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
