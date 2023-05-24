using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models.Entities;

public class Bike
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string VIN { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Model { get; set; } = null!;
    public BikeType BikeType { get; set; }
    public int WheelSize { get; set; }
    public BikeFrameSize FrameSize { get; set; }
    public BikeState State { get; set; }
    public long UserId { get; set; }
    public List<ServiceEvent> ServiceHistory { get; set; } = new List<ServiceEvent>();
    public bool Insured { get; set; }

    public override string ToString()
    {
        return
            $"VIN: {VIN}, Insured: {Insured}, Manufacturer: {Manufacturer}, Model: {Model}, BikeType: {BikeType.ToString()}, Wheel size: {WheelSize}.";
    }
}