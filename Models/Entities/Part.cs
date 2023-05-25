using System.ComponentModel.DataAnnotations.Schema;

namespace BikeServiceAPI.Models.Entities;

public class Part
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;

    public double Price { get; set; }

    public string Description { get; set; } = null!;

    public Transaction Transaction { get; set; } = null!;

    public override string ToString()
    {
        return $"Model: {Model}, Price: {Price}.";
    }
}