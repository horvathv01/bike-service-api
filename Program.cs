using BikeServiceAPI.DAL;
using BikeServiceAPI.Models;
using BikeServiceAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var corsName = "localhost";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsName,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<BikeServiceContext>(options =>
    
    options.UseNpgsql(builder.Configuration.GetConnectionString("BikeServiceConnection")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
builder.Services.AddSingleton<IRepository<Bike>, InMemoryBikeRepository>();
builder.Services.AddSingleton<IBikeService, BikeService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsName);

app.UseAuthorization();

app.MapControllers();

app.Run();