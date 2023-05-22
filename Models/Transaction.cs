namespace BikeServiceAPI.Models;

public record Transaction(int Id, int TotalPrice, User User, List<Part> PurchasedItems);