using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.DTOs;

public class TourDto
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; }
    public string Difficulty { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public List<UserDto> Participants { get; set; } = new List<UserDto>();

    public TourDto()
    {
    }

    public TourDto(Tour tour)
    {
        Id = tour.Id;
        Name = tour.Name;
        Type = tour.Type.ToString();
        Difficulty = tour.Difficulty.ToString();
        Start = tour.Start;
        End = tour.End;
        Participants = tour.Participants.Select(user => new UserDto(user)).ToList();
    }
}