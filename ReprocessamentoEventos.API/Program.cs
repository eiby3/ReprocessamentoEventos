using ReprocessamentoEventos.Application.Services.MontagemListas;
using ReprocessamentoEventos.Application.Services.Queries;
using ReprocessamentoEventos.Application.Services.Reprocessamento;
using ReprocessamentoEventos.Application.Services.SeparadorDeIdentificadorEvento;
using ReprocessamentoEventos.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReprocessamentoService, ReprocessamentoService>();
builder.Services.AddScoped<IMontagemListasService, MontagemListasService>();
builder.Services.AddScoped<ISeparadorDeIdentificadorEventoService, SeparadorDeIdentificadorEventoService>();
builder.Services.AddScoped<IQueriesService, QueriesService>();

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
