using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.DTOs;

public class UserDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string? Introduction { get; set; }
    public bool Premium { get; set; }
    public List<BikeDto>? Bikes { get; set; } = new List<BikeDto>();
    public List<string>? Tours { get; set; } = new List<string>();
    public List<string>? TransactionHistory { get; set; } = new List<string>();

    public UserDto()
    {
    }

    public UserDto(User user)
    {
        Name = user.Name;
        Email = user.Email;
        Password = user.Password;
        Phone = user.Phone;
        Introduction = user.Introduction;

        Premium = user.Premium;
        Bikes = user.Bikes.Select(bike => new BikeDto(bike)).ToList();
        Tours = ParseTours(user.Tours);
        TransactionHistory = ParseTransactionHistory(user.TransactionHistory);
    }

    public List<string> ParseTours(List<Tour> tours) => tours.Select(tour => tour.ToString()).ToList();
    public List<string> ParseTransactionHistory(List<Transaction> transactions) => transactions.Select(transaction => transaction.ToString()).ToList();
}