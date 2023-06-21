namespace BikeServiceAPI.Models.Entities;

public record Insurance(Bike bike, int Price, DateTime Start, DateTime End);