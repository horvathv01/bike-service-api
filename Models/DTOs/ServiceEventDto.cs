using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.DTOs;

public class ServiceEventDto
{
    public long Id { get; set; }

    public string? Type { get; set; } = null!;
    public DateTime? Start { get; set; } = null!;
    public DateTime? End { get; set; } = null!;
    public double? Price { get; set; } = null!;
    public BikeDto Bike { get; set; } = null!;
    //public Person User { get; set; } = null!;
    public ColleagueDto Colleague { get; set; } = null!;

    public ServiceEventDto(ServiceEvent serviceEvent)
    {
        Id = serviceEvent.Id;
        Type = serviceEvent.Type.ToString();
        Start = serviceEvent.Start;
        End = serviceEvent.End;
        Price = serviceEvent.Price;
        Bike = new BikeDto(serviceEvent.Bike);
        Colleague = new ColleagueDto(serviceEvent.Colleague);
    }
    
}