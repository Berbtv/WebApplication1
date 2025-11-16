using Application.Interfaces.Data;
using Application.Interfaces.Services;
using Application.Services;
using Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options=>options.UseInMemoryDatabase("mydb"));
builder.Services.AddScoped<IAppDbContext>(provider=>provider.GetRequiredService<AppDbContext>());
builder.Services.AddScoped<IUnitofWork>(provider => provider.GetRequiredService<AppDbContext>());
builder.Services.AddScoped<ICompanyService, FuelStationService>();
builder.Services.AddScoped<ICompanyService, ServiceCompanyService>();
builder.Services.AddScoped<ICompanyService, VehicleOwnerService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
