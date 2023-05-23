using System.ComponentModel.DataAnnotations.Schema;

namespace BikeServiceAPI.Models;

public class Transaction
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public double? TotalPrice { get; set; } = null!;
    public User? User { get; set; } = null!;
    public List<Part> PurchasedItems { get; set; }
}