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
    public async Task<List<BikeDto>> GetAllBikes()
    {
        return await _bikeService.GetAllBikes();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBikeById(long id)
    {
        try
        {
            return Ok(await _bikeService.GetBikeById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.StackTrace);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddBike([FromBody] BikeDto bikeDto)
    {
        return Ok(await _bikeService.AddBike(bikeDto));
    }


    [HttpPut]
    public async Task<IActionResult> UpdateBike([FromBody] BikeDto bikeDto)
    {
        try
        {
            return Ok(await _bikeService.UpdateBike(bikeDto));
        }
        catch (Exception e)
        {
            return BadRequest(e.StackTrace);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBike(long id)
    {
        try
        {
            return Ok(await _bikeService.DeleteBike(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.StackTrace);
        }
    }
}