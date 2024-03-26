using Microsoft.EntityFrameworkCore;
using APIPruebas.Models;
using System.Text.Json.Serialization;
using APIPruebas.algoritmo;
using APIPruebas.Clases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexion con el modelo para poder usado en nuestros calculadores
builder.Services.AddDbContext<DbapiContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("conexionSQL")));

// Ignorar la referencias ciclicas 
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<IProductoLogic, ProductosServices>(); // Ajusta el alcance según sea necesario


var app = builder.Build();

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
