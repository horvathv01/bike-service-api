using BikeServiceAPI.Models.Entities;

namespace BikeServiceAPI.Models.DTOs;

public class BikeDto
{
    public long Id { get; set; }
    public string VIN { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public string BikeType { get; set; }
    public int WheelSize { get; set; }
    public string FrameSize { get; set; }
    public string State { get; set; }
    public long UserId { get; set; }
    public List<string> ServiceHistory { get; set; }
    public bool Insured { get; set; }

    public BikeDto()
    {
    }

    public BikeDto(Bike bike)
    {
        Id = bike.Id;
        VIN = bike.VIN;
        Manufacturer = bike.Manufacturer;
        Model = bike.Model;
        BikeType = bike.BikeType.ToString();
        WheelSize = bike.WheelSize;
        FrameSize = bike.FrameSize.ToString();
        State = bike.State.ToString();
        UserId = bike.UserId;
        ServiceHistory = GetServiceList(bike.ServiceHistory);
        Insured = bike.Insured;
    }

    private List<string> GetServiceList(List<ServiceEvent> serviceHistory)
    {
        return serviceHistory.Select(serviceEvent => serviceEvent.ToString()).ToList();
    }
}