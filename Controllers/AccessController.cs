using BikeServiceAPI.Auth;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BikeServiceAPI.Controllers;

[ApiController, Route("[controller]")]
public class AccessController : ControllerBase
{
    private readonly IUserService _userService;

    public AccessController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    [AuthorizeWithToken]
    //[AllowAnonymous]
    public IActionResult RegisterUser([FromBody] UserDto user)
    {
        _userService.AddUser(user);
        return Ok();
    }

    [HttpPost("login")]
    [Authorize]
    public async Task<IActionResult> LoginUser()
    {
        return Ok();
    }

    [HttpPost("logout")]
    [AllowAnonymous]
    public async Task<IActionResult> LogoutUser()
    {
        await HttpContext.SignOutAsync();
        return Ok();
    }
    
}