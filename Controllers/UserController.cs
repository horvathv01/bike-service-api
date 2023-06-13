using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BikeServiceAPI.Controllers;

[ApiController, Route("[controller]")]
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
        return await _userService.GetAllUsers();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(long id)
    {
        try
        {
            return Ok(await _userService.GetUserById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.StackTrace);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
    {
        await _userService.AddUser(userDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
    {
        try
        {
            return Ok(await _userService.UpdateUser(userDto));
        }
        catch (Exception e)
        {
            return BadRequest(e.StackTrace);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        var databaseIdClaim =  User.Claims.FirstOrDefault(c => c.Type == "DatabaseID");
        string databaseId = "";
        if (databaseIdClaim != null)
        {
            databaseId = databaseIdClaim.Value;
        }

        if (User.IsInRole("Admin") || databaseId == id.ToString())
        {
            try
            {
                return Ok(await _userService.DeleteUser(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        return BadRequest("You have no authority to delete this user.");
    }
}