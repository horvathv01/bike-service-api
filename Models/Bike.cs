using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public class Bike
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string VIN { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Model { get; set; } = null!;
    public BikeType? Type { get; set; } = null!;
    public int? WheelSize { get; set; } = null!;
    public BikeFrameSize? FrameSize { get; set; } = null!;
    public BikeState? State { get; set; } = null!;

    public User? Owner { get; set; } = null!;
    public List<ServiceEvent> ServiceHistory { get; set; } = null!;
    public bool? Insured { get; set; } = null!;
    
    // public Bike(string vin, string manufacturer, string model, BikeType type, int wheelSize, BikeFrameSize frameSize, BikeState state, bool insured)
    // {
    //     VIN = vin;
    //     Manufacturer = manufacturer;
    //     Model = model;
    //     Type = type;
    //     WheelSize = wheelSize;
    //     FrameSize = frameSize;
    //     State = state;
    //     ServiceHistory = new List<ServiceEvent>();
    //     Insured = insured;
    // }
}