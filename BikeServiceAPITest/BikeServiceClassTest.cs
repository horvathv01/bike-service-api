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
    public async Task GetBikeByIdTest()
    {
        BikeDto bike;
        using (var context = new MockContext(_options))
        {
            BikeService bikeService = new BikeService(context);
            UserService userService = new UserService(context);
            await FillInMemoryDatabaseWithData(bikeService, userService);
            var allBikes = await bikeService.GetAllBikes();
            var id = allBikes.FirstOrDefault().Id;
            bike = await bikeService.GetBikeById(id);
        }
        
        Assert.That(bike, !Is.Null);
    }

    [Test]
    public async Task DeleteBikeTest()
    {
        BikeDto bike;
        List<BikeDto> bikes;
        using (var context = new MockContext(_options))
        {
            BikeService bikeService = new BikeService(context);
            UserService userService = new UserService(context);
            await FillInMemoryDatabaseWithData(bikeService, userService);
            var allBikes = await bikeService.GetAllBikes();
            bike = allBikes.FirstOrDefault();
            Console.WriteLine($"bike found: {bike.Id}");
            await bikeService.DeleteBike(bike.Id);
            bikes = await bikeService.GetAllBikes();
        }
        
        Assert.That(!bikes.Contains(bike));
    }

    [Test]
    public async Task UpdateBikeTest()
    {
        BikeDto bike;
        string manufacturer = "Csirke";
        using (var context = new MockContext(_options))
        {
            BikeService bikeService = new BikeService(context);
            UserService userService = new UserService(context);
            await FillInMemoryDatabaseWithData(bikeService, userService);
            var allBikes = await bikeService.GetAllBikes();
            var bike1 = allBikes.FirstOrDefault();
            bike1.Manufacturer = manufacturer;
            await bikeService.UpdateBike(bike1);
            bike = await bikeService.GetBikeById(bike1.Id);
        }
        
        Assert.That(bike.Manufacturer, Is.EqualTo(manufacturer));
    }

    [Test]
    public async Task AddBikeTest()
    {
        Random random = new Random();
        string manufacturer = "Csirke";
        List<BikeDto> bikes;
        var bike = new Bike();
        bike.VIN = $"VIN-{random.Next(0, 8)}";
        bike.Manufacturer = manufacturer;
        bike.Model = "Model";
        bike.BikeType = (BikeType)random.Next(0, Enum.GetNames(typeof(BikeType)).Length - 1);
        bike.WheelSize = random.Next(12, 28);
        bike.FrameSize = (BikeFrameSize)random.Next(0, Enum.GetNames(typeof(BikeFrameSize)).Length - 1);
        bike.State = (BikeState)random.Next(0, Enum.GetNames(typeof(BikeState)).Length - 1);
        bike.UserId = random.Next(0, 9);
        bike.Insured = random.Next(0, 10) % 2 == 0;
        
        var bikeDto = new BikeDto(bike);
        using (var context = new MockContext(_options))
        {
            BikeService bikeService = new BikeService(context);
            UserService userService = new UserService(context);
            await FillInMemoryDatabaseWithData(bikeService, userService);
            await bikeService.AddBike(bikeDto);
            bikes = await bikeService.GetAllBikes();
        }

        var selection = bikes.Where(b => b.Manufacturer == manufacturer);
            
        Assert.That(selection, !Is.Null);
    }
}
