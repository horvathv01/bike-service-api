using System.Transactions;

namespace BikeServiceAPI.Models;

public class User : Person
{
	public bool? Premium { get; set; } = null!;
	public List<Bike> Bikes { get; set; } = new List<Bike>();
	public List<Tour>? Tours { get; set; } = null;
	//public List<ServiceEvent> ServiceEvents { get; set; } = null!;
	public List<Transaction> TransactionHistory { get; set; } = null!;
	public List<Bike> InsuredBikes { get; set; } = new List<Bike>();

    // public User(long id, string name, string email, string password, string phone, string? introduction = null) : base(id, name, email, password, phone, introduction)
    // {
    // }
}