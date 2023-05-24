using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.DTOs;

public class ColleagueDto
{
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string? Introduction { get; set; }

    public string SkillLevel { get; set; } = null!;

    public List<string> ServiceEvents { get; set; } = null!;

    public ColleagueDto(Colleague colleague)
    {
        Name = colleague.Name;
        Email = colleague.Email;
        Password = colleague.Password;
        Phone = colleague.Password;
        Introduction = colleague.Introduction;
        SkillLevel = colleague.SkillLevel.ToString();
        ServiceEvents = colleague.ServiceEvents.Select(ev => $"Start: {ev.Start}, end: {ev.End}, price: {ev.Price}, service event type: {ev.Type.ToString()}, Bike VIN {ev.Bike.VIN}.").ToList();
    }
}