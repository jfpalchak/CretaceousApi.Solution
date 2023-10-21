using CretaceousApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CretaceousApiContext>(
									dbContextOptions => dbContextOptions
										.UseMySql(
											builder.Configuration["ConnectionStrings:DefaultConnection"],
											ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
											)
										)
									);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

// We'll use HTTPS only when NOT in development.
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
