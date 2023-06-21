using BikeServiceAPI.Enums;
using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Models.Entities;

public class Tour
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public TourType Type { get; set; }
    public TourDifficulty Difficulty { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public List<User> Participants { get; set; } = new List<User>();

    public Tour()
    {
        
    }

    public Tour(TourDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Type = Enum.Parse<TourType>(dto.Type);
        Difficulty = Enum.Parse<TourDifficulty>(dto.Difficulty);
        Start = dto.Start;
        End = dto.End;
    }

    public override string ToString()
    {
        return $"{Name}, {Type}, {Difficulty}, {Start} - {End}";
    }
}