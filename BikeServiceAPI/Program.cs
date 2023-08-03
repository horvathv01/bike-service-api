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
            policy.WithOrigins("http://localhost:3000", "http://192.168.1.209:3000", "http://192.168.1.242:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

string[] connectionNames = { "BikeServiceConnection", "BikeService@Vili" };
string connectionString = null;

builder.Services.AddDbContext<BikeServiceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(connectionNames[1])));

builder.Services.AddDbContext<BikeServiceContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString(connectionNames[0]))
    );

if (connectionString == null)
{
    Console.WriteLine("Failed to connect to any database.");
}
// Add services to the container.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        options.Cookie.Name = "BikeServiceCookie";
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
builder.Services.AddTransient<IBikeService, BikeService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IServiceEventService, ServiceEventService>();
builder.Services.AddTransient<IColleagueService, ColleagueService>();
builder.Services.AddSingleton<IAccessUtilities, AccessUtilities>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors(corsName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();