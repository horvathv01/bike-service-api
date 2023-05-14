namespace BikeServiceAPI.Models;

public record Transaction(int Id, int TotalPrice, StandardUser User, List<Part> PurchasedItems);