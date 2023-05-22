using BikeServiceAPI.Enums;
using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Models;

public class Tour
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public TourType? Type { get; set; } = null!;
    public TourDifficulty? Difficulty { get; set; } = null!;
    public DateTime? Start { get; set; } = null!;
    public DateTime? End { get; set; } = null!;
    private List<User> Participants { get; set; } = null!;
}