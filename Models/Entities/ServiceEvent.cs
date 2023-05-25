using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Enums;
using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Models.Entities;

public class ServiceEvent
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public ServiceEventType Type { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public double Price { get; set; }
    public long BikeId { get; set; }
    public long ColleagueId { get; set; }

    public ServiceEvent()
    {
        
    }

    public ServiceEvent(ServiceEventDto dto)
    {
        Id = dto.Id;
        Type = Enum.Parse<ServiceEventType>(dto.Type);
        Start = dto.Start;
        End = dto.End;
        Price = dto.Price;
        BikeId = dto.BikeId;
        ColleagueId = dto.ColleagueId;
    }
}