using BikeServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeServiceAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BikeController : Controller
{
    private readonly IBikeService _bikeService;

    public BikeController(IBikeService bikeService)
    {
        _bikeService = bikeService;
    }

    [HttpGet("allBikes")]
    public IActionResult GetAllBikes()
    {
        return Ok(_bikeService.GetAll());
    }
}