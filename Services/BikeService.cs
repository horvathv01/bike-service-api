using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
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

    public async Task<int> AddBike(BikeDto bikeDto)
    {
        var bike = new Bike(bikeDto);
        _context.Bikes.Add(bike);
        return await _context.SaveChangesAsync();
    }

    public async Task<BikeDto> GetBikeById(long id)
    {
        var bike = await GetBikeEntityById(id) ?? throw new InvalidOperationException("bike with id not exist");

        return new BikeDto(bike);
    }

    public async Task<int> UpdateBike(BikeDto bikeDto)
    {
        Bike bike = await GetBikeEntityById(bikeDto.Id) ??
                    throw new InvalidOperationException("bike with id not exist");
        var updateBike = new Bike(bikeDto);

        _context.Entry(bike).CurrentValues.SetValues(updateBike);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteBike(long id)
    {
        Bike bike = await GetBikeEntityById(id) ?? throw new InvalidOperationException("bike with id not exist");
        _context.Bikes.Remove(bike);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<BikeDto>> GetAllBikes()
    {
        var bikeList = await _context.Bikes
            .Include(bike => bike.ServiceHistory)
            .ToListAsync();
        return bikeList.Select(bike => new BikeDto(bike)).ToList();
    }

    private async Task<Bike?> GetBikeEntityById(long id)
    {
        var bike = await _context.Bikes
            .Include(bike => bike.ServiceHistory)
            .FirstOrDefaultAsync(bike => bike.Id == id);

        return bike;
    }
}