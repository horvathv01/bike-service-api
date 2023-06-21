using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Auth;

public interface IAccessUtilities
{
    string HashPassword(string password);
    Task<bool> AuthenticateUser(User? user, string password);
    
}