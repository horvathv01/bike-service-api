namespace BikeServiceAPI.Models.DTOs;

public class ServiceEventDTO
{
    public long Id { get; set; }

    public string? Type { get; set; } = null!;
    public DateTime? Start { get; set; } = null!;
    public DateTime? End { get; set; } = null!;
    public double? Price { get; set; } = null!;
    public BikeDTO Bike { get; set; } = null!;
    //public Person User { get; set; } = null!;
    public ColleagueDTO Colleague { get; set; } = null!;

    public ServiceEventDTO(ServiceEvent serviceEvent)
    {
        Id = serviceEvent.Id;
        Type = serviceEvent.Type.ToString();
        Start = serviceEvent.Start;
        End = serviceEvent.End;
        Price = serviceEvent.Price;
        Bike = new BikeDTO(serviceEvent.Bike);
        Colleague = new ColleagueDTO(serviceEvent.Colleague);
    }
    
}