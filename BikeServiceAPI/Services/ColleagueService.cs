using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPI.Services;

public class ColleagueService : IColleagueService
{
    private readonly BikeServiceContext _context;

    public ColleagueService(BikeServiceContext context)
    {
        _context = context;
    }

    public async Task<int> AddColleague(ColleagueDto colleagueDto)
    {
        var colleague = new Colleague(colleagueDto);
        colleague.Password = HashPassword(colleague.Password);
        _context.Colleagues.Add(colleague);
        return await _context.SaveChangesAsync();
    }

    public async Task<ColleagueDto> GetColleagueById(long id)
    {
        var colleague = await GetColleagueEntityById(id);
        return new ColleagueDto(colleague);
    }

    public async Task<int> UpdateColleague(ColleagueDto colleagueDto)
    {
        var colleague = await GetColleagueEntityById(colleagueDto.Id);
        var updateColleague = new Colleague(colleagueDto);
        
        _context.Entry(colleague).CurrentValues.SetValues(updateColleague);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteColleague(long id)
    {
        var colleague = await GetColleagueEntityById(id);
        _context.Colleagues.Remove(colleague);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<ColleagueDto>> GetAllColleague()
    {
        var colleagueList = await _context.Colleagues
            .Include(colleague => colleague.ServiceEvents)
            .ToListAsync();
        return colleagueList.Select(colleague => new ColleagueDto(colleague)).ToList();
    }
    private async Task<Colleague> GetColleagueEntityById(long id)
    {
        var colleague = await _context.Colleagues.FirstOrDefaultAsync(colleague => colleague.Id == id);
        return colleague ?? throw new InvalidOperationException("User not found by the given id.");
    }
    public string HashPassword(string password)
    {
        var passwordHasher = new PasswordHasher<string>();
        return passwordHasher.HashPassword("BikeServiceSalt", password);
    }
}