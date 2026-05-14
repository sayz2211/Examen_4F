using Microsoft.EntityFrameworkCore;
using SAAcademiaMatriculas_Lib_Servicios.Implementaciones;
using SAAcademiaMatriculas_Lib_Servicios.Nucleo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var conexion = new Conexion();
conexion.string_conexion = Configuraciones.obtener("string_conexion");
conexion.Database.Migrate();

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
