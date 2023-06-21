using BikeServiceAPI.Auth;
using BikeServiceAPI.DAL;
using BikeServiceAPI.Enums;
using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;
using BikeServiceAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPITest;

public class ServiceEventServiceTest
{
         private DbContextOptions<BikeServiceContext>? _options;
    
    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<BikeServiceContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

    }

    private async Task FillInMemoryDatabaseWithData(ServiceEventService serviceEventService, BikeService bikeService, 
        UserService userService, ColleagueService colleagueService)
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
            
            string colName = $"ServiceEventName-{i}";
            string colEmail = $"{name}@bikeservice.ru";
            string colPassword = $"user{i}";
            string colPhone = $"+3670/111-111{i}";
            var currentColleague = new Colleague(colName, colEmail, colPassword, colPhone);
            currentColleague.Roles.Add(Role.Colleague);
            await colleagueService.AddColleague(new ColleagueDto(currentColleague));
            
            ServiceEvent serviceEvent = new ServiceEvent();
            serviceEvent.Type = (ServiceEventType)random.Next(0, Enum.GetNames(typeof(ServiceEventType)).Length - 1);
            serviceEvent.Start = DateTime.Today;
            serviceEvent.End = DateTime.Today.AddDays(1);
            serviceEvent.Price = random.Next(10, 8000);
            serviceEvent.BikeId = currentBike.Id;
            serviceEvent.ColleagueId = currentColleague.Id;
            await serviceEventService.AddServiceEvent(new ServiceEventDto(serviceEvent));

        }
    }

    [Test]
    public async Task GetallServiceEventsTest()
    {
        IAccessUtilities accessUtilities = new AccessUtilities();
        List<ServiceEventDto> allServiceEvents;
        using (var context = new MockContext(_options))
        {
            ServiceEventService serviceEventService = new ServiceEventService(context);
            BikeService bikeService = new BikeService(context);
            UserService userService = new UserService(context, accessUtilities);
            ColleagueService colleagueService = new ColleagueService(context);
            await FillInMemoryDatabaseWithData(serviceEventService, bikeService, userService, colleagueService);
            allServiceEvents = await serviceEventService.GetAllServiceEvent();
            //serviceEventService.AddServiceEvent()
            //serviceEventService.DeleteServiceEvent()
            //serviceEventService.UpdateServiceEvent()
            //serviceEventService.GetServiceEventById()
            //serviceEventService.GetAllServiceEvent()
        }
        
        Assert.That(allServiceEvents.Count, !Is.Null);
    }

    [Test]
    public async Task GetServiceEventByIdTest()
    {
        IAccessUtilities accessUtilities = new AccessUtilities();
        ServiceEventDto ServiceEvent;
        using (var context = new MockContext(_options))
        {
            ServiceEventService serviceEventService = new ServiceEventService(context);
            BikeService bikeService = new BikeService(context);
            UserService userService = new UserService(context, accessUtilities);
            ColleagueService colleagueService = new ColleagueService(context);
            await FillInMemoryDatabaseWithData(serviceEventService, bikeService, userService, colleagueService);
            var allServiceEvents = await serviceEventService.GetAllServiceEvent();
            var id = allServiceEvents.FirstOrDefault().Id;
            ServiceEvent = await serviceEventService.GetServiceEventById(id);
        }
        
        Assert.That(ServiceEvent, !Is.Null);
    }

    [Test]
    public async Task DeleteServiceEventTest()
    {
        IAccessUtilities accessUtilities = new AccessUtilities();
        ServiceEventDto serviceEvent;
        List<ServiceEventDto> serviceEvents;
        using (var context = new MockContext(_options))
        {
            ServiceEventService serviceEventService = new ServiceEventService(context);
            BikeService bikeService = new BikeService(context);
            UserService userService = new UserService(context, accessUtilities);
            ColleagueService colleagueService = new ColleagueService(context);
            await FillInMemoryDatabaseWithData(serviceEventService, bikeService, userService, colleagueService);
            var allServiceEvents = await serviceEventService.GetAllServiceEvent();
            serviceEvent = allServiceEvents.FirstOrDefault();
            await serviceEventService.DeleteServiceEvent(serviceEvent.Id);
            serviceEvents = await serviceEventService.GetAllServiceEvent();
        }
        
        Assert.That(!serviceEvents.Contains(serviceEvent));
    }

    [Test]
    public async Task UpdateServiceEventTest()
    {
        IAccessUtilities accessUtilities = new AccessUtilities();
        ServiceEventDto ServiceEvent;
        DateTime start = DateTime.Now;
        using (var context = new MockContext(_options))
        {
            ServiceEventService serviceEventService = new ServiceEventService(context);
            BikeService bikeService = new BikeService(context);
            UserService userService = new UserService(context, accessUtilities);
            ColleagueService colleagueService = new ColleagueService(context);
            await FillInMemoryDatabaseWithData(serviceEventService, bikeService, userService, colleagueService);
            var allServiceEvents = await serviceEventService.GetAllServiceEvent();
            var ServiceEvent1 = allServiceEvents.FirstOrDefault();
            ServiceEvent1.Start = start;
            await serviceEventService.UpdateServiceEvent(ServiceEvent1);
            ServiceEvent = await serviceEventService.GetServiceEventById(ServiceEvent1.Id);
        }
        
        Assert.That(ServiceEvent.Start, Is.EqualTo(start));
    }

    [Test]
    public async Task AddServiceEventTest()
    {
        IAccessUtilities accessUtilities = new AccessUtilities();
        Random random = new Random();
        List<ServiceEventDto> serviceEvents;
        
        DateTime start = DateTime.Now;

        var serviceEvent = new ServiceEvent();
        serviceEvent.Type = (ServiceEventType)random.Next(0, Enum.GetNames(typeof(ServiceEventType)).Length - 1);
        serviceEvent.Start = start;
        serviceEvent.End = DateTime.Today.AddDays(1);
        serviceEvent.Price = random.Next(10, 8000);
        serviceEvent.BikeId = random.Next(0, 5);
        serviceEvent.ColleagueId = random.Next(0, 9);
        

        var serviceEventDto = new ServiceEventDto(serviceEvent);
        using (var context = new MockContext(_options))
        {
            ServiceEventService serviceEventService = new ServiceEventService(context);
            BikeService bikeService = new BikeService(context);
            UserService userService = new UserService(context, accessUtilities);
            ColleagueService colleagueService = new ColleagueService(context);
            await FillInMemoryDatabaseWithData(serviceEventService, bikeService, userService, colleagueService);
            await serviceEventService.AddServiceEvent(serviceEventDto);
            serviceEvents = await serviceEventService.GetAllServiceEvent();
        }

        var selection = serviceEvents.Where(e => e.Start == start);
            
        Assert.That(selection, !Is.Null);
    }
}