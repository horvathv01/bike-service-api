namespace BikeServiceAPI.Models;

public class PremiumUser : StandardUser
{
    //can access QuickService 
    public List<Bike> InsuredBikes { get; private set; } = new List<Bike>();
    
    public PremiumUser(long id, string name, string email, string password, string phone, string? introduction = null) : base(id, name, email, password, phone, introduction)
    {
    }

    public Bike InsureBike(Bike bike)
    {
        InsuredBikes.Add(bike);
        //changes in database have to be made!
        return bike;
    }

    public Bike UnInsureBike(Bike bike)
    {
        InsuredBikes.Remove(bike);
        //changes in database have to be made!
        return bike;
    }
}