using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Services;

public interface IBikeService
{
    public Task<int> AddBike(BikeDto bikeDto);

    public Task<BikeDto> GetBikeById(long id);

    public Task<int> UpdateBike(BikeDto bikeDto);

    public Task<int> DeleteBike(long id);

    public Task<List<BikeDto>> GetAllBikes();
}