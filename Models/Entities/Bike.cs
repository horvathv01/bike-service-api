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
    public BikeType? Type { get; set; }
    public int? WheelSize { get; set; }
    public BikeFrameSize? FrameSize { get; set; }
    public BikeState? State { get; set; }

    public User? Owner { get; set; }
    public List<ServiceEvent> ServiceHistory { get; set; } = null!;
    public bool Insured { get; set; }
}