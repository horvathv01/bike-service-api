using System.Runtime.InteropServices.JavaScript;
using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public class ServiceEvent
{
    public long Id { get; set; }
    public ServiceEventType Type { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public double Price { get; set; }
    public Bike Bike { get; set; }
    public Person User { get; set; }
    public Person Colleague { get; set; }
}
