using BikeServiceAPI.Enums;

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
    
    public override string ToString()
    {
        return $"{Name}, {Type}, {Difficulty}, {Start} - {End}";
    }
}