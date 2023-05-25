using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Models.Entities;

public class Part
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; }

    public Part()
    {
        
    }

    public Part(PartDto dto)
    {
        Id = dto.Id;
        Make = dto.Make;
        Model = dto.Model;
        Price = dto.Price;
        Description = dto.Description;
    }

    public override string ToString()
    {
        return $"Model: {Model}, Price: {Price}.";
    }
}