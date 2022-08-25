using HackathonService.Dtos;
using HackathonService.Persistency;

namespace HackathonService.Queries
{
    public class Events : IEvents
    {
        private readonly HackContext _context;

        public Events(HackContext context)
        {
            _context = context;
        }
        public async Task<HackathonEvent> GetById(Guid Id)
        {
            var eventByID = await _context.Events.FindAsync(Id);
            if (eventByID == null)
                return new HackathonEvent();
            return eventByID;   
        }
    }
}
