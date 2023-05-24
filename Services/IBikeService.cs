using BikeServiceAPI.Models;
using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Services;

public interface IBikeService
{
    public Task AddBike(Bike bike);

    public Task<Bike> GetBikeById(long id);

    public Task UpdateBike(Bike bike, long id);

    public Task DeleteBike(long id);

    public Task<List<Bike>> GetAllBikes();
}