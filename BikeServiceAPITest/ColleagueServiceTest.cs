using BikeServiceAPI.DAL;
using BikeServiceAPI.Enums;
using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;
using BikeServiceAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPITest;

public class ColleagueServiceTest
{
     private DbContextOptions<BikeServiceContext>? _options;
    
    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<BikeServiceContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

    }

    private async Task FillInMemoryDatabaseWithData(ColleagueService colleagueService)
    {
        Random random = new Random();
        int num = 8;
        for (int i = 0; i < num; i++)
        {
            string name = $"ColleagueName-{i}";
            string email = $"{name}@bikeservice.ru";
            string password = $"user{i}";
            string phone = $"+3670/111-111{i}";
            var currentColleague = new Colleague(name, email, password, phone);
            currentColleague.Roles.Add(Role.Colleague);
            await colleagueService.AddColleague(new ColleagueDto(currentColleague));
        }
    }

    [Test]
    public async Task GetAllColleaguesTest()
    {
        List<ColleagueDto> allColleagues;
        using (var context = new MockContext(_options))
        {
            ColleagueService colleagueService = new ColleagueService(context);
            await FillInMemoryDatabaseWithData(colleagueService);
            allColleagues = await colleagueService.GetAllColleague();
        }
        
        Assert.That(allColleagues.Count, !Is.Null);
    }

    [Test]
    public async Task GetColleagueByIdTest()
    {
        ColleagueDto colleague;
        using (var context = new MockContext(_options))
        {
            ColleagueService colleagueService = new ColleagueService(context);
            await FillInMemoryDatabaseWithData(colleagueService);
            var allColleagues = await colleagueService.GetAllColleague();
            var id = allColleagues.FirstOrDefault().Id;
            colleague = await colleagueService.GetColleagueById(id);
        }
        
        Assert.That(colleague, !Is.Null);
    }

    [Test]
    public async Task DeleteColleagueTest()
    {
        ColleagueDto colleague;
        List<ColleagueDto> colleagues;
        using (var context = new MockContext(_options))
        {
            ColleagueService colleagueService = new ColleagueService(context);
            await FillInMemoryDatabaseWithData(colleagueService);
            var allColleagues = await colleagueService.GetAllColleague();
            colleague = allColleagues.FirstOrDefault();
            Console.WriteLine($"bike found: {colleague.Id}");
            await colleagueService.DeleteColleague(colleague.Id);
            colleagues = await colleagueService.GetAllColleague();
        }
        
        Assert.That(!colleagues.Contains(colleague));
    }

    [Test]
    public async Task UpdateColleagueTest()
    {
        ColleagueDto colleague;
        string newName = "Csirke";
        using (var context = new MockContext(_options))
        {
            ColleagueService colleagueService = new ColleagueService(context);
            await FillInMemoryDatabaseWithData(colleagueService);
            var allColleagues = await colleagueService.GetAllColleague();
            var colleague1 = allColleagues.FirstOrDefault();
            colleague1.Name = newName;
            await colleagueService.UpdateColleague(colleague1);
            colleague = await colleagueService.GetColleagueById(colleague1.Id);
        }
        
        Assert.That(colleague.Name, Is.EqualTo(newName));
    }

    [Test]
    public async Task AddColleagueTest()
    {
        Random random = new Random();
        List<ColleagueDto> colleagues;
        
        
        string name = $"Test Colleague";
        string email = "test@bikeservice.ru";
        string password = $"testuser";
        string phone = $"+3670/111-1111";
        var colleague = new Colleague(name, email, password, phone);

        var colleagueDto = new ColleagueDto(colleague);
        using (var context = new MockContext(_options))
        {
            ColleagueService colleagueService = new ColleagueService(context);
            await FillInMemoryDatabaseWithData(colleagueService);
            await colleagueService.AddColleague(colleagueDto);
            colleagues = await colleagueService.GetAllColleague();
        }

        var selection = colleagues.Where(c => c.Name == name);
            
        Assert.That(selection, !Is.Null);
    }
}
