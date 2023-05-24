using BikeServiceAPI.DAL;
using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;
using BikeServiceAPI.Models.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPI.Services;

public class UserService : IUserService
{
    private readonly BikeServiceContext _context;
    private readonly IMapper<User,UserDto> _userDtoMapper;

    public UserService(BikeServiceContext context, IMapper<User, UserDto> userDtoMapper)
    {
        _context = context;
        _userDtoMapper = userDtoMapper;
    }

    public async Task<List<UserDto>> GetAllUsers()
    {
        var userList = await _context.Users
            .Include(user => user.Bikes)
            .Include(user => user.Tours)
            .Include(user => user.TransactionHistory)
            .ToListAsync();
        return userList.Select(user => _userDtoMapper.ToDto(user)).ToList();
    }

    public async Task<UserDto> GetUserById(long id)
    {
        var user = await GetUserEntityById(id) ?? throw new InvalidOperationException("User not exist.");
        return _userDtoMapper.ToDto(user);
    }

    public async Task<int> AddUser(UserDto userDto)
    {
        var user = _userDtoMapper.ToEntity(userDto);
        _context.Users.Add(user);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateUser(UserDto userDto)
    {
        var user = await GetUserEntityById(userDto.Id) ?? throw new InvalidOperationException("User not exist.");
        var updatedUser = _userDtoMapper.ToEntity(userDto);

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

        return user;
    }
}