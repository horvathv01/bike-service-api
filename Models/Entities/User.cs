using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Models.Entities;

public class User : Person
{
    public bool Premium { get; set; }
    public List<Bike> Bikes { get; set; } = new List<Bike>();
    public List<Tour> Tours { get; set; } = new List<Tour>();
    public List<Transaction>? TransactionHistory { get; set; } = new List<Transaction>();

    public User(string name, string email, string password, string phone, string? introduction = null)
        : base(name, email, password, phone, introduction)
    {
    }

    public User(UserDto dto) : base(dto.Name, dto.Email, dto.Password, dto.Phone, dto.Introduction)
    {
        Premium = dto.Premium;
        Bikes = dto.Bikes.Select(bikeDto => new Bike(bikeDto)).ToList();
        Tours = dto.Tours.Select(tourDto => new Tour(tourDto)).ToList();
        TransactionHistory = dto.TransactionHistory.Select(transactionDto => new Transaction(transactionDto)).ToList();
    }
}