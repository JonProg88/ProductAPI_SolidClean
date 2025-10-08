using Microsoft.EntityFrameworkCore;
using ProductosAPI.Data;
using ProductosAPI.Repositories;
using ProductosAPI.Services;
//using ProductAPI_SolidClean.Data;
//using ProductAPI_SolidClean.Repositories;
//using ProductAPI_SolidClean.Services;


var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddControllers();


// Configuro conexion a SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// inyeciones de dependencias (principio de inversion)
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();



// Swagger para probar endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
