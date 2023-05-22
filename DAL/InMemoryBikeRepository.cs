using BikeServiceAPI.Enums;
using BikeServiceAPI.Models;

namespace BikeServiceAPI.DAL;

public class InMemoryBikeRepository : IRepository<Bike>
{
    private readonly List<Bike> _bikes;

    public InMemoryBikeRepository()
    {
        _bikes = new List<Bike>()
        {
            new Bike("VIN", "manufacturer", "model", BikeType.CityBike, 10,BikeFrameSize.S,BikeState.New,false )
        };
    }

    public void Add(Bike bike)
    {
        _bikes.Add(bike);
    }

    public Bike GetById(long id)
    {
        return _bikes.FirstOrDefault(bike => bike.Id == id)!;
    }

    public void Update(Bike bike)
    {
        var bikeToUpdate = GetById(bike.Id);
        
        bikeToUpdate.State = bike.State;
        bikeToUpdate.Type = bike.Type;
        bikeToUpdate.Model = bike.Model;
        bikeToUpdate.Manufacturer = bike.Manufacturer;
        bikeToUpdate.VIN = bike.VIN;
        bikeToUpdate.Insured = bike.Insured;
        bikeToUpdate.FrameSize = bike.FrameSize;
        bikeToUpdate.WheelSize = bike.WheelSize;
        bikeToUpdate.ServiceHistory = bike.ServiceHistory;
    }

    public void Delete(long id)
    {
        _bikes.Remove(_bikes.FirstOrDefault(bike => bike.Id == id)!);
    }

    public IEnumerable<Bike> GetAll()
    {
        return _bikes;
    }
}