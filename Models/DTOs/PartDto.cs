using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.DTOs;

public class PartDto
{
    public long Id { get; set; }

    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;

    public PartDto()
    {
        
    }

    public PartDto(Part part)
    {
        Id = part.Id;
        Make = part.Make;
        Model = part.Model;
        Price = part.Price;
        Description = part.Description;
    }
}