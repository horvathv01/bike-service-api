using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.DTOs;

public class UserDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Introduction { get; set; }
    public bool Premium { get; set; }
    public List<BikeDto> Bikes { get; set; } = new List<BikeDto>();
    public List<TourDto> Tours { get; set; } = new List<TourDto>();
    public List<TransactionDto> TransactionHistory { get; set; } = new List<TransactionDto>();

    public List<string> Roles { get; set; } = new List<string>();

    public UserDto()
    {
    }

    public UserDto(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
        Password = user.Password;
        Phone = user.Phone;
        Introduction = user.Introduction;

        Premium = user.Premium;
        Bikes = user.Bikes.Select(bike => new BikeDto(bike)).ToList();
        Tours = user.Tours.FirstOrDefault() != null ? user.Tours.Select(tour => new TourDto(tour)).ToList() : new List<TourDto>();
        TransactionHistory = user.TransactionHistory.FirstOrDefault() != null ? user.TransactionHistory.Select(transaction => 
            new TransactionDto(transaction)).ToList() : new List<TransactionDto>();
        Roles = user.Roles.Select(role => role.ToString()).ToList();
    }
}