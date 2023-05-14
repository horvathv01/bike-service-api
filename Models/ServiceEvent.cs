using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public record ServiceEvent(ServiceEventType Type, DateTime Start, DateTime End, int Price, List<Part> PartsNeeded, List<Tool> ToolsNeeded);
