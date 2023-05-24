using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public class Colleague : Person
{
    public SkillLevel? SkillLevel { get; set; }

    public List<ServiceEvent> ServiceEvents { get; set; } = null!;
    public Colleague(string name, string email, string password, string phone, SkillLevel? skillLevel = null, string? introduction = null) : base(name, email, password, phone, introduction)
    {
        SkillLevel = skillLevel;
    }
}