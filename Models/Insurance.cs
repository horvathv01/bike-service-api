namespace BikeServiceAPI.Models;

public record Insurance(Bike bike, int Price, DateTime Start, DateTime End);