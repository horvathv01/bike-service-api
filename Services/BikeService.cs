using BikeServiceAPI.Models;
using BikeServiceAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPI.Services;

public class BikeService : IBikeService
{
    private readonly BikeServiceContext _context;

    public BikeService(BikeServiceContext context)
    {
        _context = context;
    }

    public async Task AddBike(Bike bike)
    {
        long id = await _context.Bikes.CountAsync() + 1;
        bike.Id = id;
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
        if (bike == null)
        {
            return;
        }
        
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