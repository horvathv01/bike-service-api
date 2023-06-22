using BikeServiceAPI.Auth;
using BikeServiceAPI.DAL;
using BikeServiceAPI.Enums;
using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;
using BikeServiceAPI.Services;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPITest;

public class DtoToEntityTest
{
    private Random random;
    [SetUp]
    public void Setup()
    {
        random = new Random();
    }

    [Test]
    public void Bike()
    {
        BikeDto dto = new BikeDto();
        dto.Id = 1;
        dto.VIN = $"VIN-{1}";
        dto.Manufacturer = "Manufacturer";
        dto.Model = "Model";
        dto.BikeType = ((BikeType)random.Next(0, Enum.GetNames(typeof(BikeType)).Length - 1)).ToString();
        dto.WheelSize = random.Next(12, 28);
        dto.FrameSize = ((BikeFrameSize)random.Next(0, Enum.GetNames(typeof(BikeFrameSize)).Length - 1)).ToString();
        dto.State = ((BikeState)random.Next(0, Enum.GetNames(typeof(BikeState)).Length - 1)).ToString();
        dto.UserId = 1;
        dto.Insured = random.Next(0, 10) % 2 == 0;

        Bike bike = new Bike(dto);
        var properties = typeof(Bike).GetProperties();
        bool result = true;
        foreach (var property in properties)
        {
            var value = property.GetValue(bike);
            if (value == null)
            {
                result = false;
            }
        }
        
        Assert.That(result);

    }

    [Test]
    public void Colleague()
    {
        ColleagueDto dto = new ColleagueDto();
        dto.Id = 1;
        dto.Name = "TestColleague";
        dto.Email = "test@bikeservice.ru";
        dto.Password = "colleague";
        dto.Phone = "+3670/111-1111";
        dto.SkillLevel = "Beginner";
        dto.Introduction = "Csirke vagyok";
        dto.ServiceEvents = new List<ServiceEventDto>();
        dto.Roles.Add(Role.Colleague.ToString());
        
        Colleague colleague = new Colleague(dto);
        var properties = typeof(Colleague).GetProperties();
        bool result = true;
        foreach (var property in properties)
        {
            var value = property.GetValue(colleague);
            if (value == null)
            {
                result = false;
            }
        }
        
        Assert.That(result);
        
    }
    
    [Test]
    public void Part()
    {
        PartDto dto = new PartDto();
        dto.Id = 1;
        dto.Model = "csirke";
        dto.Make = "pulyka";
        dto.Price = 9;
        dto.Description = "csirkePulyka";

        Part part = new Part(dto);
        var properties = typeof(Part).GetProperties();
        bool result = true;
        foreach (var property in properties)
        {
            var value = property.GetValue(part);
            if (value == null)
            {
                result = false;
            }
        }
        
        Assert.That(result);
    }
    
    [Test]
    public void ServiceEvent()
    {
            int i = 1;
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

            string colName = $"ServiceEventName-{i}";
            string colEmail = $"{name}@bikeservice.ru";
            string colPassword = $"user{i}";
            string colPhone = $"+3670/111-111{i}";
            var currentColleague = new Colleague(colName, colEmail, colPassword, colPhone);
            currentColleague.Roles.Add(Role.Colleague);

            ServiceEventDto dto = new ServiceEventDto();
            dto.Type = ((ServiceEventType)random.Next(0, Enum.GetNames(typeof(ServiceEventType)).Length - 1)).ToString();
            dto.Start = DateTime.Today;
            dto.End = DateTime.Today.AddDays(1);
            dto.Price = random.Next(10, 8000);
            dto.BikeId = currentBike.Id;
            dto.ColleagueId = currentColleague.Id;
            
            ServiceEvent serviceEvent = new ServiceEvent(dto);
            var properties = typeof(ServiceEvent).GetProperties();
            bool result = true;
            foreach (var property in properties)
            {
                var value = property.GetValue(serviceEvent);
                if (value == null)
                {
                    result = false;
                }
            }
        
            Assert.That(result);


    }
    
    [Test]
    public void Tour()
    {
        string name = $"Test User";
        string email = "test@bikeservice.ru";
        string password = $"testuser";
        string phone = $"+3670/111-1111";
        var user = new User(name, email, password, phone);
        UserDto userDto = new UserDto(user);
        TourDto dto = new TourDto();
        dto.Id = 1;
        dto.Name = "testTour";
        dto.Type = TourType.Individual.ToString();
        dto.Difficulty = TourDifficulty.Extreme.ToString();
        dto.Start = DateTime.Today;
        dto.End = dto.Start.AddDays(1);
        dto.Participants.Add(userDto);

        Tour tour = new Tour(dto);
        var properties = typeof(Tour).GetProperties();
        bool result = true;
        foreach (var property in properties)
        {
            var value = property.GetValue(tour);
            if (value == null)
            {
                result = false;
            }
        }
        
        Assert.That(result);
        
    }
    
    [Test]
    public void Transaction()
    {
        PartDto item = new PartDto();
        item.Id = 1;
        item.Model = "csirke";
        item.Make = "pulyka";
        item.Price = 9;
        item.Description = "csirkePulyka";
        
        UserDto user = new UserDto();
        user.Name = "Test User";
        user.Email = "test@bikeservice.ru";
        user.Password = "testuser";
        user.Phone = "+3670/111-1111";
        user.Premium = false;

        TransactionDto dto = new TransactionDto();
        dto.Id = 1;
        dto.TotalPrice = 5000;
        dto.User = user;
        dto.PurchasedItems.Add(item);
        
        Transaction transaction = new Transaction(dto);
        var properties = typeof(Transaction).GetProperties();
        bool result = true;
        foreach (var property in properties)
        {
            var value = property.GetValue(transaction);
            if (value == null)
            {
                result = false;
            }
        }
        
        Assert.That(result);
    }
    
    [Test]
    public void User()
    {
        BikeDto bike = new BikeDto();
        bike.Id = 1;
        bike.VIN = $"VIN-{1}";
        bike.Manufacturer = "Manufacturer";
        bike.Model = "Model";
        bike.BikeType = ((BikeType)random.Next(0, Enum.GetNames(typeof(BikeType)).Length - 1)).ToString();
        bike.WheelSize = random.Next(12, 28);
        bike.FrameSize = ((BikeFrameSize)random.Next(0, Enum.GetNames(typeof(BikeFrameSize)).Length - 1)).ToString();
        bike.State = ((BikeState)random.Next(0, Enum.GetNames(typeof(BikeState)).Length - 1)).ToString();
        bike.UserId = 1;
        bike.Insured = random.Next(0, 10) % 2 == 0;
        
        
        
        UserDto dto = new UserDto();
        dto.Name = "Test User";
        dto.Email = "test@bikeservice.ru";
        dto.Password = "testuser";
        dto.Phone = "+3670/111-1111";
        dto.Premium = false;
        dto.Bikes.Add(bike);
        dto.Roles.Add(Role.StandardUser.ToString());
        dto.Introduction = "csirke vagyok";
        
        TourDto tour = new TourDto();
        tour.Id = 1;
        tour.Name = "testTour";
        tour.Type = TourType.Individual.ToString();
        tour.Difficulty = TourDifficulty.Extreme.ToString();
        tour.Start = DateTime.Today;
        tour.End = tour.Start.AddDays(1);
        tour.Participants.Add(dto);
        dto.Tours.Add(tour);

        var user = new User(dto);
        var properties = typeof(User).GetProperties();
        bool result = true;
        foreach (var property in properties)
        {
            var value = property.GetValue(user);
            
            if (value == null)
            {
                Console.WriteLine($"íme a hiba: {property.Name}, value: {value}");    
                result = false;
            }
        }
        
        Assert.That(result);
        
        
    }
    
    
}