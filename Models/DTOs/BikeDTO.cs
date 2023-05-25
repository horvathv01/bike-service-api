using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models.DTOs;

public class BikeDTO
{
    public long Id { get; set; }

    public string VIN { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }
    public int? WheelSize { get; set; }
    public string FrameSize { get; set; }
    public string State { get; set; }

    public string OwnerName { get; set; }
    public List<string> ServiceHistory { get; set; }
    public bool? Insured { get; set; }

    public BikeDTO(Bike bike)
    {
        VIN = bike.VIN;
        Manufacturer = bike.Manufacturer;
        Model = bike.Model;
        Type = bike.Type.ToString();
        WheelSize = bike.WheelSize;
        FrameSize = bike.FrameSize.ToString();
        State = bike.State.ToString();
        OwnerName = bike.Owner.Name;
        ServiceHistory = bike.ServiceHistory == null ? new List<string>() : bike.ServiceHistory.Select(ev => $"Start: {ev.Start}, end: {ev.End}, price: {ev.Price}, service event type: {ev.Type.ToString()}, Bike VIN {ev.Bike.VIN}.").ToList();
        Insured = bike.Insured;
    }
}