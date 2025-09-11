using EpiManager.Application.Interfaces;
using EpiManager.Application.UseCases;
using EpiManager.Infrastructure.Data;
using EpiManager.Infrastructure.Repositories;
using EpiManager.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<EpiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IGuidGenerator, GuidGeneratorService>();
builder.Services.AddScoped<IEpiRepository, EpiRepository>();
builder.Services.AddScoped<CreateEpiUseCase>();
builder.Services.AddScoped<GetEpiByIdUseCase>();
builder.Services.AddScoped<ListEpisUseCase>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
