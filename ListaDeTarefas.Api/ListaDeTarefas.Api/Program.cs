using AutoMapper;
using ListaDeTarefas.Api.ViewModels;
using ListaDeTarefas.Application.DTO;
using ListaDeTarefas.Application.Interfaces;
using ListaDeTarefas.Application.Repositories;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Infra.Context;
using ListaDeTarefas.Infra.Interfaces;
using ListaDeTarefas.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddDbContext<ApplicationContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString(("ListaDeTarefas"))));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapper
var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Tarefa, TarefaDTO>().ReverseMap();
    cfg.CreateMap<CriarTarefaViewModel, TarefaDTO>().ReverseMap();
});
#endregion

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirTudo");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
