using BikeServiceAPI.Auth;
using BikeServiceAPI.Models;
using BikeServiceAPI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddDbContext<BikeServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BikeServiceConnection")));
    //options.UseNpgsql(builder.Configuration.GetConnectionString("BikeService@Vili")));
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