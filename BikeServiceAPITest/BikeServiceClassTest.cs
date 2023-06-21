using BikeServiceAPI.DAL;
using BikeServiceAPI.Enums;
using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;
using BikeServiceAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPITest;

public class BikeServiceClassTest
{
    private DbContextOptions<BikeServiceContext>? _options;
    
    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<BikeServiceContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

    }

    private async Task FillInMemoryDatabaseWithData(BikeService bikeService, UserService userService)
    {
        Random random = new Random();
        int num = 8;
        for (int i = 0; i < num; i++)
        {
            //bike
            Bike currentBike = new Bike();
            currentBike.VIN = $"VIN-{i}";
            currentBike.Manufacturer = "Manufacturer";
            currentBike.Model = "Model";
            currentBike.BikeType = (BikeType)random.Next(0, Enum.GetNames(typeof(BikeType)).Length - 1);
            currentBike.WheelSize = random.Next(12, 28);
            currentBike.FrameSize = (BikeFrameSize)random.Next(0, Enum.GetNames(typeof(BikeFrameSize)).Length - 1);
            currentBike.State = (BikeState)random.Next(0, Enum.GetNames(typeof(BikeState)).Length - 1);
            currentBike.UserId = i;
            currentBike.Insured = random.Next(0, 10) % 2 == 0;
            
            //user
            //string name, string email, string password, string phone, string? introduction = null
            string name = $"UserName-{i}";
            string email = $"{name}@bikeservice.ru";
            string password = $"user{i}";
            string phone = $"+3670/111-111{i}";
            User currentUser = new User(name, email, password, phone);
            currentUser.Roles.Add(Role.StandardUser);
            currentUser.Bikes.Add(currentBike);
            await userService.AddUser(new UserDto(currentUser));
            await bikeService.AddBike(new BikeDto(currentBike));
        }
    }

    [Test]
    public async Task GetAllBikesTest()
    {
        List<BikeDto> allBikes;
        using (var context = new MockContext(_options))
        {
            BikeService bikeService = new BikeService(context);
            UserService userService = new UserService(context);
            await FillInMemoryDatabaseWithData(bikeService, userService);
            allBikes = await bikeService.GetAllBikes();
        }
        
        Assert.That(allBikes.Count, !Is.Null);
    }

    [Test]
    public async Task FindBikeById()
    {
        
    }
}