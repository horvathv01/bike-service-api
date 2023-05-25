using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.DTOs;

public class ColleagueDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string? Introduction { get; set; }
    public string SkillLevel { get; set; }
    public List<ServiceEventDto> ServiceEvents { get; set; }

    public ColleagueDto()
    {
        
    }

    public ColleagueDto(Colleague colleague)
    {
        Id = colleague.Id;
        Name = colleague.Name;
        Email = colleague.Email;
        Password = colleague.Password;
        Phone = colleague.Password;
        Introduction = colleague.Introduction;
        SkillLevel = colleague.SkillLevel.ToString();
        ServiceEvents = colleague.ServiceEvents.Select(serviceEvent => new ServiceEventDto(serviceEvent)).ToList();
    }
}