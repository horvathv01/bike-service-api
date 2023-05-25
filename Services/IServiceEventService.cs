using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Services;

public interface IServiceEventService
{
    public Task<int> AddServiceEvent(ServiceEventDto serviceEventDto);
    public Task<ServiceEventDto> GetServiceEventById(long id);
    public Task<int> UpdateServiceEvent(ServiceEventDto serviceEventDto);
    public Task<int> DeleteServiceEvent(long id);
    public Task<List<ServiceEventDto>> GetAllServiceEvent();
}