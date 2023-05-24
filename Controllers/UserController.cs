using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;
using BikeServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeServiceAPI.Controllers;
[ApiController, Route("/{controller}")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<UserDto>> GetAllUsers()
    {
        var result = await _userService.GetAllUsers();
        return result.Select(user => new UserDto(user)).ToList();
    }

    [HttpGet("/{controller}/{id}")]
    public async Task<UserDto> GetUserById(long id)
    {
        var result = await _userService.GetUserById(id);
        return new UserDto(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewUser([FromBody] User user)
    {
        await _userService.AddNewUser(user);
        return Ok();
    }

    [HttpPut("/{controller}/{id}")]
    public async Task<IActionResult> UpdateUser([FromBody] User user, long id)
    {
        await _userService.UpdateUser(user, id);
        return Ok();
    }

    [HttpDelete("/{controller}/{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        await _userService.DeleteUser(id);
        return Ok();
    }


}