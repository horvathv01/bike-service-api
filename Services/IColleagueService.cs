using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Services;

public interface IColleagueService
{
    public Task<int> AddColleague(ColleagueDto bikeDto);

    public Task<ColleagueDto> GetColleagueById(long id);

    public Task<int> UpdateColleague(ColleagueDto bikeDto);

    public Task<int> DeleteColleague(long id);

    public Task<List<ColleagueDto>> GetAllColleague();
}