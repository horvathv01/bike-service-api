using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public class Colleague : Person
{
    public SkillLevel SkillLevel { get; private set; }
    public Colleague(int id, string name, string email, string password, string phone, SkillLevel skillLevel, string? introduction = null) : base(id, name, email, password, phone, introduction)
    {
        SkillLevel = skillLevel;
    }
    public SkillLevel ChangeSkillLevel(SkillLevel skillLevel)
    {
        SkillLevel = skillLevel;
        return skillLevel;
    }
}