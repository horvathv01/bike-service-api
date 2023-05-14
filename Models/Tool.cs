using BikeServiceAPI.Enums;

namespace BikeServiceAPI.Models;

public record Tool(int Id, ToolType Type, List<ServiceEventType> ServiceEventCompatibility);