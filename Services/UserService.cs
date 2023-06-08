using BikeServiceAPI.Auth;
using BikeServiceAPI.Enums;
using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPI.Services;

public class UserService : IUserService
{
    private readonly BikeServiceContext _context;

    public UserService(BikeServiceContext context)
    {
        _context = context;
    }

    public async Task<List<UserDto>> GetAllUsers()
    {
        var userList = await _context.Users
            .Include(user => user.Bikes)
            .Include(user => user.Tours)
            .Include(user => user.TransactionHistory)
            .ToListAsync();
        return userList.Select(user => new UserDto(user)).ToList();
    }

    public async Task<UserDto> GetUserById(long id)
    {
        var user = await GetUserEntityById(id) ?? throw new InvalidOperationException("User not exist.");
        return new UserDto(user);
    }

    public async Task<User> GetUserByName(string userName)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Name == userName);
        return user ?? throw new InvalidOperationException("User not exist.");
    }


    public async Task<int> AddUser(UserDto userDto)
    {
        var user = new User(userDto);
        user.Password = HashPassword(user.Password);
        _context.Users.Add(user);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateUser(UserDto userDto)
    {
        var user = await GetUserEntityById(userDto.Id) ?? throw new InvalidOperationException("User not exist.");
        var updatedUser = new User(userDto);
        _context.Entry(user).CurrentValues.SetValues(updatedUser);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteUser(long id)
    {
        var user = await GetUserEntityById(id) ?? throw new InvalidOperationException("User not exist.");
        _context.Users.Remove(user);
        return await _context.SaveChangesAsync();
    }

    private async Task<User?> GetUserEntityById(long id)
    {
        var user = await _context.Users
            .Include(user => user.Bikes)
            .Include(user => user.TransactionHistory)
            .Include(user => user.Tours)
            .FirstOrDefaultAsync(user => user.Id == id);

        return user ?? throw new InvalidOperationException("User not exist.");
    }

    public string HashPassword(string password)
    {
        var passwordHasher = new PasswordHasher<string>();
        return passwordHasher.HashPassword("BikeServiceSalt", password);
    }

    public async Task<bool> AuthenticateUser(string userName, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == userName);

        if (user == null)
        {
            return false;
        }

        var passwordHasher = new PasswordHasher<string>();
        var result = passwordHasher.VerifyHashedPassword("BikeServiceSalt", user.Password, password);
        return result == PasswordVerificationResult.Success;
    }
}