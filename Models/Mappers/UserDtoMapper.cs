using BikeServiceAPI.Models.DTOs;
using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.Mappers;

public class UserDtoMapper: IMapper<User, UserDto>
{
    public User ToEntity(UserDto dto)
    {
        return new User(dto.Name,dto.Email,dto.Password,dto.Phone,dto.Introduction)
        {
            Id = dto.Id,
            Bikes = new List<Bike>(),
            Introduction = dto.Introduction,
            Premium = dto.Premium,
            Tours = new List<Tour>(),
            TransactionHistory = new List<Transaction>()
        };
    }

    public UserDto ToDto(User entity)
    {
        return new UserDto(entity);
    }
}