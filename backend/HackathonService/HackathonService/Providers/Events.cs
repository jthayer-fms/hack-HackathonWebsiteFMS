using HackathonService.Dtos;

namespace HackathonService.Queries
{
    public class Events :IEvents
    {
        public Events()
        { 
        }
        public async Task<HackathonEvent> GetById(Guid Id)
        {
            var exisitingEvent = new HackathonEvent();
            return exisitingEvent;
        }
    }
}
