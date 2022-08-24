using HackathonService.Dtos;

namespace HackathonService.Queries
{
    public interface IEvents
    {
        Task<HackathonEvent> GetById(Guid Id);
    }
}
