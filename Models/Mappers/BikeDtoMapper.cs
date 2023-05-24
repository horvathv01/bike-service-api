using BikeServiceAPI.Enums;
using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.Mappers;

public class BikeDtoMapper : IMapper<Bike, BikeDto>
{
    public Bike ToEntity(BikeDto dto)
    {
        var bike = new Bike
        {
            Id = dto.Id,
            VIN = dto.VIN,
            Manufacturer = dto.Manufacturer,
            Model = dto.Model,
            BikeType = Enum.Parse<BikeType>(dto.BikeType),
            WheelSize = dto.WheelSize,
            FrameSize = Enum.Parse<BikeFrameSize>(dto.FrameSize),
            State = Enum.Parse<BikeState>(dto.State),
            UserId = dto.UserId,
            ServiceHistory = new List<ServiceEvent>(), // TODO make mapper for service event!
            Insured = dto.Insured
        };
        return bike;
    }

    public BikeDto ToDto(Bike entity)
    {
        return new BikeDto(entity);
    }
}