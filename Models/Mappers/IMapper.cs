namespace BikeServiceAPI.Models.Mappers;

public interface IMapper<T,TU>
{
    public T ToEntity(TU dto);
    public TU ToDto(T entity);
}