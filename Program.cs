using BikeServiceAPI.Auth;
using BikeServiceAPI.Models;
using BikeServiceAPI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var corsName = "localhost";
AuthUser.ServiceToken = builder.Configuration.GetValue<string>("Token");

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsName,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

string[] connectionNames = { "BikeServiceConnection", "BikeService@Vili" };
string connectionString = null;

foreach (string connectionName in connectionNames)
{
    string currentConnectionString = builder.Configuration.GetConnectionString(connectionName);

    if (currentConnectionString != null)
    {
        if (connectionName == "BikeServiceConnection")
        {
            try
            {
                builder.Services.AddDbContext<BikeServiceContext>(options =>
                    options.UseSqlServer(currentConnectionString));

                connectionString = currentConnectionString;
                break;
            }
            catch (SqlException)
            {
                Console.WriteLine($"Failed to connect to SQL Server");
            }
        }
        else if (connectionName == "BikeService@Vili")
        {
            try
            {
                builder.Services.AddDbContext<BikeServiceContext>(options =>
                    options.UseNpgsql(currentConnectionString));

                connectionString = currentConnectionString;
                break;
            }
            catch (NpgsqlException)
            {
                Console.WriteLine($"Failed to connect to PostgreSQL");
            }
        }
    }
}

if (connectionString == null)
{
    Console.WriteLine("Failed to connect to any database.");
}
// Add services to the container.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "BikeServiceCookie";
        options.LoginPath = "/access/login";
        options.AccessDeniedPath = "/access/denied";
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
builder.Services.AddTransient<IBikeService, BikeService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IServiceEventService, ServiceEventService>();
builder.Services.AddTransient<IColleagueService, ColleagueService>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();