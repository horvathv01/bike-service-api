using System.ComponentModel.DataAnnotations.Schema;

namespace BikeServiceAPI.Models.Entities;

public class Part
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;

    public double? Price { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public Transaction Transaction { get; set; }

    //public List<Bike> Compatibility { get; set; } = null!;
}