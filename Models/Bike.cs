using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public class Bike
{
    public int Id { get; set; }
    public string VIN { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public BikeType Type { get; set; }
    public int WheelSize { get; set; }
    public BikeFrameSize FrameSize { get; set; }
    public BikeState State { get; set; }
    public List<ServiceEvent> ServiceHistory { get; set; }
    public bool Insured { get; set; }
    
    public Bike(string vin, string manufacturer, string model, BikeType type, int wheelSize, BikeFrameSize frameSize, BikeState state, bool insured)
    {
        VIN = vin;
        Manufacturer = manufacturer;
        Model = model;
        Type = type;
        WheelSize = wheelSize;
        FrameSize = frameSize;
        State = state;
        ServiceHistory = new List<ServiceEvent>();
        Insured = insured;
    }
}