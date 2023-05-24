using BikeServiceAPI.Enums;
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
    public async Task<List<BikeDTO>> GetAllBikes()
    {
        var result = await _bikeService.GetAllBikes();
        return result.Select(bike => new BikeDTO(bike)).ToList();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewBike([FromBody] Bike bike)
    {
        await _bikeService.AddBike(bike);
        return Ok();
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
    
    [HttpGet("/initialCreate")]
    public async Task<List<BikeDTO>> InitialCreate()
    {
        User user = new User("CsirkesIstvan", "csirkes@istvan.hu", "password", "+3670/111-2222");
        Bike bike = new Bike
        {
            Id = 1, VIN = "PROBABRINGA1", Manufacturer = "Gepida", Model = "Alboin",
            Type = BikeType.CrossTrekkingBike, WheelSize = 28, FrameSize = BikeFrameSize.L, State = BikeState.New,
            ServiceHistory = new List<ServiceEvent>(), Insured = false, Owner = user};

        await _bikeService.AddBike(bike);
        return await GetAllBikes();
    }
    
}