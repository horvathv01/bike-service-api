using BikeServiceAPI.DAL;
using BikeServiceAPI.Models;

namespace BikeServiceAPI.Services;

public class BikeService : IBikeService
{
    private readonly IRepository<Bike> _bikRepository;

    public BikeService(IRepository<Bike> bikRepository)
    {
        _bikRepository = bikRepository;
    }

    public void Add(Bike bike)
    {
        _bikRepository.Add(bike);
    }

    public Bike GetById(int id)
    {
        return _bikRepository.GetById(id);
    }

    public void Update(Bike bike)
    {
        _bikRepository.Update(bike);
    }

    public void Delete(int id)
    {
        _bikRepository.Delete(id);
    }

    public IEnumerable<Bike> GetAll()
    {
        return _bikRepository.GetAll();
    }
}