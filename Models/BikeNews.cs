using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public record BikeNews(long Id, BikeNewsType Type, string PictureLink, string Description);