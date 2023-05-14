using Microsoft.AspNetCore.Mvc;

namespace BikeServiceAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GreetingController : Controller
{
    [HttpGet]
    public IActionResult Greeting()
    {
        return Ok("Welcome to BikeServiceProject!");
    }
}