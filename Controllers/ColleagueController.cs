using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeServiceAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ColleagueController : ControllerBase
{
    private readonly IColleagueService _colleagueService;

    public ColleagueController(IColleagueService colleagueService)
    {
        _colleagueService = colleagueService;
    }

    [HttpGet]
    public async Task<List<ColleagueDto>> GetAllColleague()
    {
        return await _colleagueService.GetAllColleague();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetColleagueById(long id)
    {
        try
        {
            return Ok(await _colleagueService.GetColleagueById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.StackTrace);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddColleague([FromBody] ColleagueDto colleagueDto)
    {
        return Ok(await _colleagueService.AddColleague(colleagueDto));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateColleague([FromBody] ColleagueDto colleagueDto)
    {
        try
        {
            return Ok(await _colleagueService.UpdateColleague(colleagueDto));
        }
        catch (Exception e)
        {
            return BadRequest(e.StackTrace);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColleague(long id)
    {
        try
        {
            return Ok(await _colleagueService.DeleteColleague(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.StackTrace);
        }
    }
}