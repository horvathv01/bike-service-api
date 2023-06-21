using BikeServiceAPI.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace BikeServiceAPI.Auth;

public class AccessUtilities : IAccessUtilities
{
    
    
    public string HashPassword(string password)
    {
        var passwordHasher = new PasswordHasher<string>();
        return passwordHasher.HashPassword("BikeServiceSalt", password);
    }

    public async Task<bool> AuthenticateUser(User? user, string password)
    {
        if (user == null)
        {
            return false;
        }

        var passwordHasher = new PasswordHasher<string>();
        var result = passwordHasher.VerifyHashedPassword("BikeServiceSalt", user.Password, password);
        return result == PasswordVerificationResult.Success;
    }
}