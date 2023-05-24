using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public class Tool
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id;

    public ToolType? Type { get; set; } = null!;
    //public List<ServiceEventType> ServiceEventCompatibility { get; set; } = null!;

}