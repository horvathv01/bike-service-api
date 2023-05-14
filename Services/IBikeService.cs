using BikeServiceAPI.Models;

namespace BikeServiceAPI.Services;

public interface IBikeService
{
    void Add(Bike bike);
    Bike GetById(int id);
    void Update(Bike bike);
    void Delete(int id);
    IEnumerable<Bike> GetAll();
}