using System.Transactions;

namespace BikeServiceAPI.Models;

public class StandardUser : Person
{
	public List<Tour> Tours { get; private set; } = new List<Tour>();
	public List<Bike> Bikes { get; private set; } = new List<Bike>();
	public List<Transaction> TransactionHistory { get; private set; } = new List<Transaction>();

    public StandardUser(int id, string name, string email, string password, string phone, string? introduction = null) : base(id, name, email, password, phone, introduction)
    {
    }

    public Bike RegisterBike(Bike bike)
    {
	    Bikes.Add(bike);
	    //changes in database have to made!
	    return bike;
    }

    public Bike RemoveBike(Bike bike)
    {
	    Bikes.Remove(bike);
	    //changes in database have to made!
	    return bike;
    }

    public Bike SellBike(Bike bike)
    {
	    //changes in database have to made!
	    return bike;
    }

    public Tour RegisterToTour(Tour tour)
    {
	    Tours.Add(tour);
	    //changes in database have to made!
	    return tour;
    }

    public Tour CancelTour(Tour tour)
    {
	    Tours.Remove(tour);
	    //changes in database have to be made!
	    return tour;
    }

    public void Buy()
    {
	    //to be elaborated
	    //here we buy bikes/parts/accessories/services/insurance
	    //add transactions to TransactionHistory
	    //changes in database have to be made!
    }
}