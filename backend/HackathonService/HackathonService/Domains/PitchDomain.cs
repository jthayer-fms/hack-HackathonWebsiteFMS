using HackathonService.Dtos;

namespace HackathonService.Domains
{
    public class PitchDomain
    {
        public Guid eventId { get; set; }
        public Guid id { get; set; }
        public string? description { get; set; }

        public DateTime creationTime { get; } = DateTime.UtcNow;

        public User? Creator { get; set; }

        public List<User>? TeamMembers { get; set; }

        public int votes { get; set; }
    }
}
