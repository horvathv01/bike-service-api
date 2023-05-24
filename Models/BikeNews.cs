using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public record BikeNews
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public BikeNewsType? Type { get; set; } = null!;
    public string PictureLink { get; set; } = null!;
    public string Description { get; set; } = null!;
}