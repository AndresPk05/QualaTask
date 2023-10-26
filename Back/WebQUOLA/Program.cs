using Microsoft.EntityFrameworkCore;
using WebQUOLA.Application;
using WebQUOLA.Model;
using WebQUOLA.Objects.Dtos;
using WebQUOLA.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<QualaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QualaBD"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISucursal, Sucursal>();
builder.Services.AddScoped<ISucursalRepository, SucursalRepository>();
builder.Services.AddScoped<IMoneda, Moneda>();
builder.Services.AddScoped<IMonedaRepository, MonedaRepository>();  
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/sucursal", async (ISucursal sucursal, int CodigoSucursal, int PaginaActual, int CantidadRegistros) =>
{
    var request = new RequestDto
    {
        PaginaActual = PaginaActual,
        CantidadRegistros = CantidadRegistros,
        CodigoSucursal = CodigoSucursal,
    };
    var sucursales = await sucursal.GetSucursales(request);
    return sucursales;
})
.WithName("GetSucursales")
.WithOpenApi();

app.MapDelete("/sucursal/{IdSucursal}", async (ISucursal sucursal, int IdSucursal) =>
{
    var result = await sucursal.Delete(IdSucursal);
    return result;
})
.WithName("DeleteSucursal")
.WithOpenApi();

app.MapPut("/sucursal", async(ISucursal sucursal, SucursalDto request) =>
{
    var result = await sucursal.UpdateSucursal(request);
    return result;
})
.WithName("UpdateSucursal")
.WithOpenApi();

app.MapPost("/sucursal", async (ISucursal sucursal, SucursalDto request) =>
{
    var result = await sucursal.Create(request);
    return result;
})
.WithName("CreateSucursal")
.WithOpenApi();

app.MapGet("/moneda", async (IMoneda moneda) =>
{
    var monedas = await moneda.GetAll();
    return monedas;
})
.WithName("GetAllMonedas")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
