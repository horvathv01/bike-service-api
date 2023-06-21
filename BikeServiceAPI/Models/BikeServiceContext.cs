using BikeServiceAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPI.Models;

public class BikeServiceContext : DbContext
{
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Colleague> Colleagues { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BikeNews> BikeNews { get; set; }
    public DbSet<ServiceEvent> ServiceEvents { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Part> Parts { get; set; }

    public BikeServiceContext(DbContextOptions<BikeServiceContext> options) : base(options)
    {
    }
}