using BikeServiceAPI.Models;

namespace BikeServiceAPI.Services;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(long id);
    Task AddNewUser(User user);
    Task UpdateUser(User user, long id);
    Task DeleteUser(long id);
}