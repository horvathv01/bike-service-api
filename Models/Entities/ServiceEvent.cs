using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models.Entities;

public class ServiceEvent
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public ServiceEventType? Type { get; set; } = null!;
    public DateTime? Start { get; set; } = null!;
    public DateTime? End { get; set; } = null!;
    public double? Price { get; set; } = null!;
    public Bike Bike { get; set; } = null!;
    //public Person User { get; set; } = null!;
    public Colleague Colleague { get; set; } = null!;
}
