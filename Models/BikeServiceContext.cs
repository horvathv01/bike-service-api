using BikeServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPI.DAL;

public class BikeServiceContext : DbContext
{
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Colleague> Colleagues { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BikeNews> BikeNews { get; set; }
    public DbSet<ServiceEvent> ServiceEvents { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServiceEvent>()
            .HasOne(ev => ev.Bike)
            .WithMany(bike => bike.ServiceHistory)
            .HasForeignKey(ev => ev.Bike.Id);

        modelBuilder.Entity<ServiceEvent>()
            .HasOne(ev => ev.Colleague)
            .WithMany(coll => coll.ServiceEvents)
            .HasForeignKey(ev => ev.Colleague.Id);

        modelBuilder.Entity<Bike>()
            .HasOne(bike => bike.Owner)
            .WithMany(owner => owner.Bikes)
            .HasForeignKey(bike => bike.Owner.Id);
    }
}