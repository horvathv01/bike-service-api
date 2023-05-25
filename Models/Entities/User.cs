namespace BikeServiceAPI.Models.Entities;

public class User : Person
{
	public bool Premium { get; set; }
	public List<Bike>? Bikes { get; set; } = new List<Bike>();
	public List<Tour>? Tours { get; set; } = new List<Tour>();

	public List<Transaction>? TransactionHistory { get; set; } = new List<Transaction>();

	public User(string name, string email, string password, string phone, string? introduction = null) : base(name, email, password, phone, introduction)
    {
    }
}