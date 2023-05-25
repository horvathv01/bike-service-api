using BikeServiceAPI.DAL;
using BikeServiceAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPI.Services;

public class BikeService : IBikeService
{
    //private readonly IRepository<Bike> _bikRepository;
    private BikeServiceContext _context;

    public BikeService(BikeServiceContext context)
    {
        //_bikRepository = bikRepository;
        _context = context;
    }

    public async Task AddBike(Bike bike)
    {
        // long id = await _context.Bikes.CountAsync() + 1;
        // bike.Id = id;
        _context.Bikes.Add(bike);
        await _context.SaveChangesAsync();
    }

    public async Task<Bike> GetBikeById(long id)
    {
        var bike = await _context.Bikes
            .Include(bike => bike.Owner)
            .Include(bike => bike.ServiceHistory)
            .FirstOrDefaultAsync(bike => bike.Id == id);

        if (bike == null)
        {
            Console.WriteLine("Bike not found!");
            return null;
        }

        return bike;
    }

    public async Task UpdateBike(Bike newBike, long id)
    {
        Bike bike = await GetBikeById(id);
        User user = await _context.Users
            .Include(user => user.Bikes)
            .FirstOrDefaultAsync(user => user.Id == newBike.Owner.Id);
        if (bike == null)
        {
            return;
        }

        newBike.Id = bike.Id;
        _context.Entry(bike).CurrentValues.SetValues(newBike);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBike(long id)
    {
        Bike bike = await GetBikeById(id);
        _context.Bikes.Remove(bike);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Bike>> GetAllBikes()
    {
        return await _context.Bikes
            .Include(bike => bike.Owner)
            .Include(bike => bike.ServiceHistory)
            .ToListAsync();
    }
}