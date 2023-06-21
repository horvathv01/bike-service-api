using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.DTOs;

public class TransactionDto
{
    public long Id { get; set; }
    public double TotalPrice { get; set; }
    public UserDto User { get; set; }
    public List<PartDto> PurchasedItems { get; set; } = new List<PartDto>();

    public TransactionDto()
    {
        
    }

    public TransactionDto(Transaction transaction)
    {
        Id = transaction.Id;
        TotalPrice = transaction.TotalPrice;
        User = new UserDto(transaction.User);
        PurchasedItems = transaction.PurchasedItems.Select(part=>new PartDto(part)).ToList();
    }
}