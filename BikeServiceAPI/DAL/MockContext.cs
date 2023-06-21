using BikeServiceAPI.Enums;
using BikeServiceAPI.Models;
using BikeServiceAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeServiceAPI.DAL;

public class MockContext : BikeServiceContext
{
    public MockContext(DbContextOptions<BikeServiceContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .Ignore(u => u.Roles);
            
        modelBuilder.Entity<User>()
            .Ignore(u => u.TransactionHistory)
            .Ignore(u => u.Tours);
            //.Property(u => u.Roles)
            //.HasColumnName("Roles");
            modelBuilder.Entity<Tour>()
                .Ignore(t => t.Participants);
            modelBuilder.Entity<Transaction>()
                .Ignore(t => t.User);
            modelBuilder.Entity<List<Role>>()
                .HasNoKey();
        

        base.OnModelCreating(modelBuilder);
    }
}