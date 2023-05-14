using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public record BikeNews(int Id, BikeNewsType Type, string PictureLink, string Description);