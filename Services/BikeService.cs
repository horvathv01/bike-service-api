using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;
using BikeServiceAPI.Models.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPI.Services;

public class BikeService : IBikeService
{
    private readonly BikeServiceContext _context;
    private readonly IMapper<Bike, BikeDto> _bikeDtoMapper;

    public BikeService(BikeServiceContext context, IMapper<Bike, BikeDto> bikeDtoMapper)
    {
        _context = context;
        _bikeDtoMapper = bikeDtoMapper;
    }

    public async Task<int> AddBike(BikeDto bikeDto)
    {
        var bike = _bikeDtoMapper.ToEntity(bikeDto);
        _context.Bikes.Add(bike);
        return await _context.SaveChangesAsync();
    }

    public async Task<BikeDto> GetBikeById(long id)
    {
        var bike = await GetBikeEntityById(id) ?? throw new InvalidOperationException("bike with id not exist");

        return _bikeDtoMapper.ToDto(bike);
    }

    public async Task<int> UpdateBike(BikeDto bikeDto)
    {
        Bike bike = await GetBikeEntityById(bikeDto.Id) ??
                    throw new InvalidOperationException("bike with id not exist");
        var updateBike = _bikeDtoMapper.ToEntity(bikeDto);

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
        return bikeList.Select(bike => _bikeDtoMapper.ToDto(bike)).ToList();
    }

    private async Task<Bike?> GetBikeEntityById(long id)
    {
        var bike = await _context.Bikes
            .Include(bike => bike.ServiceHistory)
            .FirstOrDefaultAsync(bike => bike.Id == id);

        return bike;
    }
}