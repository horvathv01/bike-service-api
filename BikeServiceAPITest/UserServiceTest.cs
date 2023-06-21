using BikeServiceAPI.Auth;
using BikeServiceAPI.DAL;
using BikeServiceAPI.Enums;
using BikeServiceAPI.Models;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;
using BikeServiceAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceAPITest;

public class UserServiceTest
{
         private DbContextOptions<BikeServiceContext>? _options;
    
    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<BikeServiceContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

    }

    private async Task FillInMemoryDatabaseWithData(UserService userService)
    {
        int num = 8;
        for (int i = 0; i < num; i++)
        {
            string name = $"UserName-{i}";
            string email = $"{name}@bikeservice.ru";
            string password = $"user{i}";
            string phone = $"+3670/111-111{i}";
            var currentUser = new User(name, email, password, phone);
            currentUser.Roles.Add(Role.StandardUser);
            await userService.AddUser(new UserDto(currentUser));
        }
    }

    [Test]
    public async Task GetAllUsersTest()
    {
        IAccessUtilities accessUtilities = new AccessUtilities();
        List<UserDto> allUsers;
        await using (var context = new MockContext(_options))
        {
            UserService userService = new UserService(context, accessUtilities);
            await FillInMemoryDatabaseWithData(userService);
            allUsers = await userService.GetAllUsers();
            //userService.AddUser()
            //userService.DeleteColleague()
            //userService.UpdateColleague()
            //userService.GetUserById()
            //userService.GetAllUsers()
        }
        
        Assert.That(allUsers.Count, !Is.Null);
    }

    [Test]
    public async Task GetUserByIdTest()
    {
        IAccessUtilities accessUtilities = new AccessUtilities();
        UserDto user;
        await using (var context = new MockContext(_options))
        {
            UserService userService = new UserService(context, accessUtilities);
            await FillInMemoryDatabaseWithData(userService);
            var allUsers = await userService.GetAllUsers();
            var id = allUsers.FirstOrDefault().Id;
            user = await userService.GetUserById(id);
        }
        
        Assert.That(user, !Is.Null);
    }

    [Test]
    public async Task GetUserByName()
    {
        IAccessUtilities accessUtilities = new AccessUtilities();
        User user;
        await using (var context = new MockContext(_options))
        {
            UserService userService = new UserService(context, accessUtilities);
            await FillInMemoryDatabaseWithData(userService);
            var allUsers = await userService.GetAllUsers();
            var name = allUsers.FirstOrDefault().Name;
            user = await userService.GetUserByName(name);
        }
        
        Assert.That(user, !Is.Null);
    }

    [Test]
    public async Task DeleteColleagueTest()
    {
        IAccessUtilities accessUtilities = new AccessUtilities();
        UserDto user;
        List<UserDto> users;
        await using (var context = new MockContext(_options))
        {
            UserService userService = new UserService(context, accessUtilities);
            await FillInMemoryDatabaseWithData(userService);
            var allUsers = await userService.GetAllUsers();
            user = allUsers.FirstOrDefault();
            await userService.DeleteUser(user.Id);
            users = await userService.GetAllUsers();
        }
        
        Assert.That(!users.Contains(user));
    }

    [Test]
    public async Task UpdateColleagueTest()
    {
        IAccessUtilities accessUtilities = new AccessUtilities();
        UserDto user;
        string newName = "Csirke";
        await using (var context = new MockContext(_options))
        {
            UserService userService = new UserService(context, accessUtilities);
            await FillInMemoryDatabaseWithData(userService);
            var allUsers = await userService.GetAllUsers();
            var user1 = allUsers.FirstOrDefault();
            user1.Name = newName;
            await userService.UpdateUser(user1);
            user = await userService.GetUserById(user1.Id);
        }
        
        Assert.That(user.Name, Is.EqualTo(newName));
    }

    [Test]
    public async Task AddUserTest()
    {
        Random random = new Random();
        List<UserDto> users;
        
        IAccessUtilities accessUtilities = new AccessUtilities();
        
        string name = $"Test User";
        string email = "test@bikeservice.ru";
        string password = $"testuser";
        string phone = $"+3670/111-1111";
        var user = new User(name, email, password, phone);

        var userDto = new UserDto(user);
        await using (var context = new MockContext(_options))
        {
            UserService userService = new UserService(context, accessUtilities);
            await FillInMemoryDatabaseWithData(userService);
            await userService.AddUser(userDto);
            users = await userService.GetAllUsers();
        }

        var selection = users.Where(u => u.Name == name);
            
        Assert.That(selection, !Is.Null);
    }
}