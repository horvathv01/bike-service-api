using System.ComponentModel.DataAnnotations.Schema;

namespace BikeServiceAPI.Models.Entities;

public class Transaction
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public double? TotalPrice { get; set; }
    public User? User { get; set; }
    public List<Part> PurchasedItems { get; set; } = new List<Part>();
    
    public override string ToString()
    {
        return string.Concat(PurchasedItems.Select(part => part.ToString()));
    }
}