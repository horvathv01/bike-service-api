namespace BikeServiceAPI.Models;

public record Part(int Id, string Make, string Model, int Price, string Description, List<Bike> Compatibility);