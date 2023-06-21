using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Models.Entities;

public class Transaction
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public double TotalPrice { get; set; }
    public User User { get; set; }
    public List<Part> PurchasedItems { get; set; } = new List<Part>();

    public Transaction()
    {
        
    }

    public Transaction(TransactionDto dto)
    {
        Id = dto.Id;
        TotalPrice = dto.TotalPrice;
        User = new User(dto.User);
        PurchasedItems = dto.PurchasedItems.Select(partDto => new Part(partDto)).ToList();
    }

    public override string ToString()
    {
        return string.Concat(PurchasedItems.Select(part => part.ToString()));
    }
}