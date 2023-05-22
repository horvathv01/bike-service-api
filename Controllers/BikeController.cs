using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeServiceAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BikeController : ControllerBase
{
    private readonly IBikeService _bikeService;

    public BikeController(IBikeService bikeService)
    {
        _bikeService = bikeService;
    }

    [HttpGet]
    public async Task<List<Bike>> GetAllBikes()
    {
        return await _bikeService.GetAllBikes();
    }
    
    [HttpPost]
    public async Task<List<BikeDTO>> AddNewBike([FromBody] Bike bike)
    {
        var result = await _bikeService.GetAllBikes();
        return result.Select(bike => new BikeDTO(bike)).ToList();
    }
    
    
    [HttpPut("/{controller}/{id}")]
    public async Task<IActionResult> UpdateBike([FromBody] Bike bike, long id)
    {
        await _bikeService.UpdateBike(bike, id);
        return Ok();
    }
    
    [HttpDelete("/{controller}/{id}")]
    public async Task<IActionResult> DeleteBike(long id)
    {
        await _bikeService.DeleteBike(id);
        return Ok();
    }
}