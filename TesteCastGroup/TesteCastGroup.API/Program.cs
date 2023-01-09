using Microsoft.EntityFrameworkCore;
using TesteCastGroup.Domain.Helpers;
using TesteCastGroup.Domain.Repository;
using TesteCastGroup.Domain.Service;
using TesteCastGroup.Domain.Service.Interface;
using TesteCastGroup.Infrastructure.Context;
using TesteCastGroup.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service
builder.Services.AddScoped<IMunicipioService, MunicipioService>();
//Repository
builder.Services.AddScoped<IRepository<string>, MunicipioRepository>();

builder.Services.AddScoped<IContaService, ContaServico>()
    .AddScoped<IContaRepository, ContaRepository>()
    .AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("teste"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Tratamento de erros
app.UseCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
