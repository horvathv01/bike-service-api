namespace BikeServiceAPI.Models.DTOs;

public class UserDTO
{
    public long Id { get; set; }

    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string? Introduction { get; set; }
    
    public bool? Premium { get; set; } = null!;
    public List<string> Bikes { get; set; } = new List<string>();
    public List<string>? Tours { get; set; } = null;
    //public List<ServiceEvent> ServiceEvents { get; set; } = null!;
    public List<string> TransactionHistory { get; set; } = null!;
    public List<string> InsuredBikes { get; set; } = new List<string>();

    public UserDTO(User user)
    {
        Name = user.Name;
        Email = user.Email;
        Password = user.Password;
        Phone = user.Password;
        Introduction = user.Introduction;
        user.Premium = Premium;
        Bikes = user.Bikes.Select(bike => $"VIN: {bike.VIN}, Insured: {bike.Insured}, Manufacturer: {bike.Manufacturer}," +
                                          $" Model: {bike.Model}, Type: {bike.Type.ToString()}, Wheel size: {bike.WheelSize}.").ToList();
        Tours = user.Tours.Select(tour => $"{tour.Name}, {tour.Type}, {tour.Difficulty}, {tour.Start} - {tour.End}").ToList();
        TransactionHistory = user.TransactionHistory.SelectMany(ev => ev.PurchasedItems.Select(item => $"Model: {item.Model}, Price: {item.Price}.")).ToList();
        InsuredBikes = user.InsuredBikes.Select(bike => $"VIN: {bike.VIN}, Insured: {bike.Insured}, Manufacturer: {bike.Manufacturer}," +
                                                        $" Model: {bike.Model}, Type: {bike.Type.ToString()}, Wheel size: {bike.WheelSize}.").ToList();
    }
}