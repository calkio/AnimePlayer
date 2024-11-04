using AnimePlayer.Application.Service;
using AnimePlayer.Core.Repositories;
using AnimePlayer.Core.Service;
using AnimePlayer.DataAccess;
using AnimePlayer.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AnimePlayerDbContex>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AnimePlayerDbContex)));
    });

builder.Services.AddScoped<IAnimeService, AnimeService>();
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();

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
