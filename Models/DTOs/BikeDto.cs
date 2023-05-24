namespace BikeServiceAPI.Models.DTOs;

public class BikeDto
{
    public long Id { get; set; }

    public string VIN { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int? WheelSize { get; set; } = null!;
    public string FrameSize { get; set; } = null!;
    public string State { get; set; } = null!;

    public string OwnerName { get; set; } = null!;
    public List<string> ServiceHistory { get; set; } = null!;
    public bool? Insured { get; set; } = null!;

    public BikeDto(Bike bike)
    {
        VIN = bike.VIN;
        Manufacturer = bike.Manufacturer;
        Model = bike.Model;
        Type = bike.Type.ToString();
        WheelSize = bike.WheelSize;
        FrameSize = bike.FrameSize.ToString();
        State = bike.State.ToString();
        OwnerName = bike.Owner.Name;
        ServiceHistory = bike.ServiceHistory.Select(ev => $"Start: {ev.Start}, end: {ev.End}, price: {ev.Price}, service event type: {ev.Type.ToString()}, Bike VIN {ev.Bike.VIN}.").ToList();
        Insured = bike.Insured;
    }
}