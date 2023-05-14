using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public record Tour(int Id, string Name, TourType Type, TourDifficulty Difficulty, DateTime Start, DateTime End, List<Person> Participants);