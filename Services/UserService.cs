using BikeServiceAPI.DAL;
using BikeServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPI.Services;

public class UserService : IUserService
{
    private BikeServiceContext _context;

    public UserService(BikeServiceContext context)
    {
        _context = context;
    }
    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users
            .Include(user => user.Bikes)
            .Include(user => user.Tours)
            .Include(user => user.TransactionHistory)
            .ToListAsync();
    }

    public async Task<User> GetUserById(long id)
    {
        return await _context.Users
            .Include(user => user.Bikes)
            .Include(user => user.Tours)
            .Include(user => user.TransactionHistory)
            .FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task AddNewUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(User userUpdate, long id)
    {
        var user = await _context.Users
            .Include(user => user.Bikes)
            .Include(user => user.Tours)
            .Include(user => user.TransactionHistory)
            .FirstOrDefaultAsync(user => user.Id == id);
        if (user == null)
        {
            return;
        }
        _context.Entry(user).CurrentValues.SetValues(userUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(long id)
    {
        var user = await _context.Users
            .Include(user => user.Bikes)
            .Include(user => user.Tours)
            .Include(user => user.TransactionHistory)
            .FirstOrDefaultAsync(user => user.Id == id);
        if (user == null)
        {
            return;
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}