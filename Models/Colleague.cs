using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public class Colleague : Person
{
    public SkillLevel? SkillLevel { get; set; } = null!;

    public List<ServiceEvent> ServiceEvents { get; set; } = null!;
    // public Colleague(long id, string name, string email, string password, string phone, SkillLevel skillLevel, string? introduction = null) : base(id, name, email, password, phone, introduction)
    // {
    //     SkillLevel = skillLevel;
    // }
}