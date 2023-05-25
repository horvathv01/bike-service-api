using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Services;

public class ServiceEventService : IServiceEventService
{
    public Task<int> AddServiceEvent(ServiceEventDto serviceEventDto)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceEventDto> GetServiceEventById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateServiceEvent(ServiceEventDto serviceEventDto)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteServiceEvent(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceEventDto>> GetAllServiceEvent()
    {
        throw new NotImplementedException();
    }
}