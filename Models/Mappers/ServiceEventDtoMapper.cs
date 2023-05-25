using BikeServiceAPI.Enums;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.Mappers;

public class ServiceEventDtoMapper : IMapper<ServiceEvent,ServiceEventDto>
{
    public ServiceEvent ToEntity(ServiceEventDto dto)
    {
        var serviceEvent = new ServiceEvent
        {
            Id = dto.Id,
            Type = Enum.Parse<ServiceEventType>(dto.Type),
            Start = dto.Start,
            End = dto.End,
            Price = dto.Price,
            BikeId = dto.BikeId,
            ColleagueId = dto.ColleagueId
        };
        return serviceEvent;
    }

    public ServiceEventDto ToDto(ServiceEvent entity)
    {
        return new ServiceEventDto(entity);
    }
}