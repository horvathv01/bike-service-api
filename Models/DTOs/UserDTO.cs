namespace BikeServiceAPI.Models.DTOs;

public class UserDTO
{
    public long Id { get; set; }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Phone { get; private set; }
    public string Introduction { get; set; }
    
    public bool Premium { get; set; }
    public List<BikeDTO> Bikes { get; set; } = new List<BikeDTO>();
    public List<string> Tours { get; set; }
    //public List<ServiceEvent> ServiceEvents { get; set; } = null!;
    public List<string> TransactionHistory { get; set; }
    public List<string> InsuredBikes { get; set; } = new List<string>();

    public UserDTO(User user)
    {
        Name = user.Name;
        Email = user.Email;
        Password = user.Password;
        Phone = user.Password;
        Introduction = user.Introduction;
        user.Premium = Premium;
        Bikes = user.Bikes == null ? new List<BikeDTO>() : user.Bikes.Select(bike => new BikeDTO(bike)).ToList();
        Tours = user.Tours == null ? new List<string>() : user.Tours.Select(tour => $"{tour.Name}, {tour.Type}, {tour.Difficulty}, {tour.Start} - {tour.End}").ToList();
        TransactionHistory = user.TransactionHistory == null ? new List<string>() : user.TransactionHistory.SelectMany(ev => ev.PurchasedItems.Select(item => $"Model: {item.Model}, Price: {item.Price}.")).ToList();
        InsuredBikes = user.InsuredBikes == null ? new List<string>() : user.InsuredBikes.Select(bike => $"VIN: {bike.VIN}, Insured: {bike.Insured}, Manufacturer: {bike.Manufacturer}," +
                                                                                                       $" Model: {bike.Model}, Type: {bike.Type.ToString()}, Wheel size: {bike.WheelSize}.").ToList();
    }
}