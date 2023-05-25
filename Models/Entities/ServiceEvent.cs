using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models.Entities;

public class ServiceEvent
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public ServiceEventType Type { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public double Price { get; set; }
    public long BikeId { get; set; }
    public long ColleagueId { get; set; }

    public override string ToString()
    {
        return
            $"Start: {Start}, end: {End},price: {Price}, service event type: {Type.ToString()}, Bike id: {BikeId}.";
    }
}