using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Services;

public interface IUserService
{
    Task<List<UserDto>> GetAllUsers();
    Task<UserDto> GetUserById(long id);
    Task<int> AddUser(UserDto userDto);
    Task<int> UpdateUser(UserDto userDto);
    Task<int> DeleteUser(long id);
    Task<User> GetUserByName(string userName);
}